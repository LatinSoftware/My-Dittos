using Ditto.Common.Models;
using Ditto.Common.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Ditto.Infraestructure.Services;

public class GoogleCalendarService : ICalendarService
{
    private readonly CalendarService service;
    string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };
    private readonly string calendarId = "primary";
    public GoogleCalendarService(string json)
    {
        var credentials = this.GetUserCredentials(json);
        service = new CalendarService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credentials,
            ApplicationName = "Ditto Application",
            
        });
    }
    public async Task<List<CalendarEventModel>> GetEvents(EventFilterModel calendarRequest)
    {
        var request = service.Events.List(calendarId);
        request.Q = calendarRequest.Q;
        request.MaxResults = 10;
        request.ShowDeleted = false;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        
        var events = await request.ExecuteAsync();
        if (events.Items == null || events.Items.Count == 0)
        {
            Console.WriteLine("No upcoming events found.");
            return new List<CalendarEventModel>();
        }
        var eventsList = new List<CalendarEventModel>();
        foreach (var eventItem in events.Items)
        {
            eventsList.Add(new CalendarEventModel{
                Id = eventItem.Id,
                Summary = eventItem.Summary,
                Description = eventItem.Description,
                Start = eventItem.Start.DateTime,
                End = eventItem.End.DateTime,
                Status = eventItem.Status
            });
        }
        return eventsList;
    }
    public async Task<string> InsertEvent(CalendarEventModel calendarRequest)
    {
        // Define parameters of request.
        var body = new Event()
        {
            Summary = calendarRequest.Summary,
            Description = calendarRequest.Description,
            Start = new EventDateTime()
            {
                DateTime = calendarRequest.Start,
                TimeZone = "America/Santo_Domingo"
            },
            End = new EventDateTime(){
                DateTime = calendarRequest.End,
                TimeZone = "America/Santo_Domingo"
            }
        };
        
        EventsResource.InsertRequest request = service.Events.Insert(body, calendarId);
        Event createdEvent = await request.ExecuteAsync();
        Console.WriteLine("Event created: {0}", createdEvent.HtmlLink);
        return createdEvent.Id;
    }

    public async Task UpdateEvent(string eventId, CalendarEventModel calendarRequest)
    {
        var body = new Event();
        var request = service.Events.Update(body: body, eventId: eventId, calendarId: calendarId);
        Event createdEvent = await request.ExecuteAsync();
        Console.WriteLine($"Event { createdEvent.Id } created { createdEvent.HtmlLink }");
    }

    public async Task DeleteEvent(string eventId)
    {
        await service.Events.Delete(calendarId: calendarId, eventId: eventId).ExecuteAsync();
    }

    private UserCredential GetUserCredentials(string json)
    {
        using var stream = new FileStream(json, FileMode.Open, FileAccess.Read);
                
        /* The file token.json stores the user's access and refresh tokens, and is created
            automatically when the authorization flow completes for the first time. */
        string credPath = "token.json";
        var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(  
            GoogleClientSecrets.FromStream(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(credPath, true)).Result;
        Console.WriteLine("Credential file saved to: " + credPath);
        return credential;
    }
}
