using ComunicationClientAPP.Modal;

namespace ComunicationClientAPP.Manager
{
    public interface IChatManager
    {
        List<Login> GetUsersAsync();
        Task SaveMessageAsync(ChatMessage message);
        List<ChatMessage> GetConversationAsync(string contactId);
        Login GetUserDetailsAsync(string userId);
    }
}
