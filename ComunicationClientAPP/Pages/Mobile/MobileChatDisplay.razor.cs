using ComunicationClientAPP.Modal;
using Microsoft.AspNetCore.Components;

namespace ComunicationClientAPP.Pages.Mobile
{
    public partial class MobileChatDisplay
    {
        [Parameter] public string CurrentMessage { get; set; }
        [Parameter] public string CurrentUserId { get; set; }
        [Parameter] public string CurrentUserEmail { get; set; }
        [Parameter] public string ContactEmail { get; set; }
        [Parameter] public string ContactId { get; set; }

        public List<ChatMessage> messages = new List<ChatMessage>();

        public List<Login> ChatUsers = new List<Login>();

        private async Task SubmitAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(CurrentMessage) && !string.IsNullOrEmpty(ContactId))
                {
                    var chatHistory = new ChatMessage()
                    {
                        Message = CurrentMessage,
                        FromUserId = CurrentUserEmail,
                        CreatedDate = DateTime.Now,
                        ToUserId = ContactEmail,
                    };
                    messages.Add(chatHistory);
                    CurrentMessage = string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            //CurrentUserId = user.Identity.Name;
            CurrentUserEmail = "Faizan@gmail.com";
            if (!string.IsNullOrEmpty(ContactId))
            {
                await LoadUserChat(ContactId, ContactEmail);
            }

        }
        async Task LoadUserChat(string userId, string email)
        {
            ContactEmail = "Faizan@gmail.com";
            ContactId = "Faizan@gmail.com";
            ContactEmail = email;
            ContactId = userId;
            messages = _chatManager.GetConversationAsync(userId);
        }
    }
}
