using Events.Models;

namespace Events.Data 
{
    public class EventData : EventDataInterface
    {
        private readonly List<Event> events;
        private int nextId;
        public EventData()
        {
            nextId = 0;
            events = new List<Event>();
        }
         public List<Event> RetrieveAllEvents()
        {
            return events;
        }

        public Event RetrieveEvent(int id)
        {
            return events.Find(x => x.Id == id);
        }

        public void AddEvent(Event EventToBeAdded)
        {
            EventToBeAdded.Id=nextId++;
            events.Add(EventToBeAdded);

        }

        public void UpdateEvent(Event EventToBeUpdated)
        {
            var ret =events.Find(x => x.Id == EventToBeUpdated.Id);
            if(ret!= null)
            {
                ret.Location = EventToBeUpdated.Location;
                ret.Date = EventToBeUpdated.Date;
            }
        }

        public void DeleteEvent(int id)
        {
            var ret = events.Find(x => x.Id == id);
            if (ret != null)
            {
                events.Remove(ret);
            }
        }

    }
}
