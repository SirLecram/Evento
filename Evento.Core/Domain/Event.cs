using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Domain
{
    public class Event : Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public User Administrator { get; protected set; }

        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        public IEnumerable<Ticket> Tickets => _tickets;

        protected Event() : base()
        {

        }
        public Event(Guid id, string name, string description, 
            DateTime startDate, DateTime endDate, User administrator) : base(id)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            StartDate = startDate;
            EndDate = endDate;
            UpdatedAt = DateTime.UtcNow;
            Administrator = administrator;
        }

        public void AddTickets(int amount, decimal price)
        {
            var seat = _tickets.Count + 1;
            for ( int i = 0; i<amount; i++)
            {
                _tickets.Add(new Ticket(Guid.NewGuid(), this, seat, price));
                seat++;
            }
        }
    }
}
