using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CEN207_Assessment2_SystemPrototypeCompany
{
    public partial class OrderTrackerManagerForm : Form
    {
        // RabbitMQ setup variables
        private String userName = "";
        private String password = "";
        private String chatRoomName = "";
        private String queueName;
        private String exchangeName = "orderTracking";
        private IModel channel;
        private IConnection connection;

        // Keeps track of all the consumers
        private int userID = 0;
        private Dictionary<String, int> consumers;

        private String sentStatus = "Sent";

        public OrderTrackerManagerForm()
        {
            InitializeComponent();            
        }
        private void OrderTrackerManagerForm_Load(object sender, EventArgs e)
        {
            // Initialize the data grid
            dgvConsumerData.ColumnCount = 5;
            dgvConsumerData.Columns[0].Name = "Order By";
            dgvConsumerData.Columns[1].Name = "Order ID";
            dgvConsumerData.Columns[2].Name = "Delivery Date";
            dgvConsumerData.Columns[3].Name = "Ordered Date";
            dgvConsumerData.Columns[4].Name = "Order Status";

            // Create instance of consumers dictionary
            consumers = new Dictionary<string, int>();

            // Get the values from form1
            userName = LoginForm.username;
            password = LoginForm.pass;

            // Setup rabbitmq            
            queueName = Guid.NewGuid().ToString();

            var factory = new ConnectionFactory();
            factory.Uri = new Uri($"amqp://{this.userName}:{password}@localhost:5672");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            // Declare exchange and queues
            channel.ExchangeDeclare(exchange: this.exchangeName,
                                    type: ExchangeType.Fanout);

            channel.QueueDeclare(queue: this.queueName,
                                 durable: true,
                                 exclusive: true,
                                 autoDelete: true);

            channel.QueueBind(queue: this.queueName,
                              exchange: this.exchangeName,
                              routingKey: this.chatRoomName);

            StartConsume();
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            // Check for the user thats being updated and removes it from the list
            if(consumers.ContainsKey(txtbxClientName.Text))
            {
                SendMessage(txtbxClientName.Text + "1");
                dgvConsumerData[4, consumers[txtbxClientName.Text]].Value = sentStatus;
                consumers.Remove(txtbxClientName.Text);
            }
            txtbxClientName.Text = "";
        }

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            // Clears the user with a order status of sent
            for(int i = 0; i < dgvConsumerData.Rows.Count; i++)
            {
                if (String.Equals(dgvConsumerData[4, i].Value, sentStatus))
                    dgvConsumerData.Rows.RemoveAt(i);
            }
        }

        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray());
                var userID = ea.BasicProperties.UserId;
                HandleMessage(text, userID);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void SendMessage(String message)
        {
            // Send message with name
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: this.exchangeName,
                                 routingKey: this.chatRoomName,
                                 basicProperties: null,
                                 body: body);
        }

        private void HandleMessage(String msg, String sender)
        {
            // Add a new row for the user            
            // To show a value different from the date ordered
            if (!consumers.ContainsKey(sender))
            {
                
                var deliveryDate = DateTime.Today.AddDays(14);

                String[] row = new string[] { sender,
                                          userID.ToString(),
                                          deliveryDate.ToShortDateString(),
                                          DateTime.Today.ToShortDateString(),
                                          "Pending" };

                // Add the row and add the user to the dictionary
                dgvConsumerData.Rows.Add(row);
                consumers.Add(msg, userID);
                userID++;
            }
        }
    }
}