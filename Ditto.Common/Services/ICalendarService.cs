using Ditto.Common.Models;

namespace Ditto.Common.Services;

public interface ICalendarService
{
    public Task<List<CalendarEventModel>> GetEvents(EventFilterModel calendarRequest);
    public Task<string> InsertEvent(CalendarEventModel calendarRequest);
    public Task UpdateEvent(string eventId, CalendarEventModel calendarRequest);
    public Task DeleteEvent(string eventId);
}
