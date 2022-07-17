using Ditto.Common.Models;

namespace Ditto.Common.Services;

public interface ICalendarService
{
    public Task<string> InsertEvent(CalendarEventModel calendarRequest);
}
