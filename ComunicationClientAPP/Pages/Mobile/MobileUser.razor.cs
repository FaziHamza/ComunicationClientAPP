using ComunicationClientAPP.Modal;
using Microsoft.AspNetCore.Components;

namespace ComunicationClientAPP.Pages.Mobile
{
    public partial class MobileUser
    {
        public List<Login> ChatUsers = new List<Login>();
        [Parameter] public string CurrentUserEmail { get; set; }
        [Parameter] public string ContactId { get; set; }
        [Parameter] public string ContactEmail { get; set; }


        protected override async Task OnInitializedAsync()
        {
            GetUsersAsync();
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            //CurrentUserId = user.Identity.Name;
            CurrentUserEmail = "Faizan@gmail.com";

        }
        private async Task GetUsersAsync()
        {
            ChatUsers = _chatManager.GetUsersAsync();
        }
    }
}
