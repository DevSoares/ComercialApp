using System;
using System.Collections.Generic;
using System.Text;
using ComercialApp.Entities.Enums;


namespace ComercialApp.Entities
{
    class Order
    {
        public Guid Id { get; private set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; private set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order(OrderStatus status, Client client)
        {
            Id = Guid.NewGuid();
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0f;
            foreach(OrderItem item in Items)
            {
                sum += item.Price * item.Quantity;
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order ID: ");
            sb.AppendLine(Id.ToString());
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("mm/dd/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Client.ToString());
            sb.AppendLine("Order items: ");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.Append("Total price: ");
            sb.AppendLine(this.Total().ToString("F2"));

            return sb.ToString();
        }
    }
}
