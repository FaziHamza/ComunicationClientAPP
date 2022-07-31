using ComunicationClientAPP.Modal;

namespace ComunicationClientAPP.Manager
{
    public class ChatManager : IChatManager
    {

        public List<ChatMessage> GetConversationAsync(string contactId)
        {
            try
            {
                contactId = "Faizan@gmail.com";
                List<ChatMessage> messageList = new List<ChatMessage>()
                 {
                    new ChatMessage(){FromUserId="Faizan@gmail.com",Message = "Hello!",CreatedDate = Convert.ToDateTime("2022-06-11T13:29:11.8727186")},
                    new ChatMessage(){FromUserId="Faizan@gmail.com",Message = "Hello!",CreatedDate = Convert.ToDateTime("2022-06-11T13:29:32.7946347")},
                    new ChatMessage(){FromUserId="Fazi@gmail.com",Message = "how are you?",CreatedDate = Convert.ToDateTime("2022-06-11T13:30:19.5742414")},
                    new ChatMessage(){FromUserId="Faizan@gmail.com",Message = "i''m fine",CreatedDate = Convert.ToDateTime("2022-06-11T13:30:31.3776799")},
                    new ChatMessage(){FromUserId="Faizan@gmail.com",Message = "what are you doing",CreatedDate = Convert.ToDateTime("2022-06-11T13:30:46.7363156")},
                    new ChatMessage(){FromUserId="Fazi@gmail.com",Message = "working......",CreatedDate = Convert.ToDateTime("2022-06-11T13:31:41.0606207")},
                    new ChatMessage(){FromUserId="Faizan@gmail.com",Message = "Grate!",CreatedDate = Convert.ToDateTime("2022-06-11T13:31:49.1215587")},
                    new ChatMessage(){FromUserId="Fazi@gmail.com",Message = "Hi fazi !",CreatedDate = Convert.ToDateTime("2022-06-11T13:32:39.7070567")},
                    new ChatMessage(){FromUserId="Faizan@gmail.com",Message = "Hi john!",CreatedDate = Convert.ToDateTime("2022-06-11T13:33:00.2477131")},
                 };
                return messageList;

                //var data = _context.ChatMessages.ToList();
                //return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Login GetUserDetailsAsync(string userId)
        {
            return GetUsersAsync().Where(a => a.UserId == userId).FirstOrDefault();
        }

        public List<Login> GetUsersAsync()
        {
            try
            {
                List<Login> ChatUsersList = new List<Login>()
                {
                    new Login(){Id=1,UserId= "Faizan@gmail.com", Email="Faizan@gmail.com"},
                    new Login(){Id=2,UserId= "Fazi@gmail.com",Email="Fazi@gmail.com"}
                };
                //var data = _context.ChatMessages.ToList();
                return ChatUsersList;
                //var data = _context.ApplicationUsers.ToList();
                //return data;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task SaveMessageAsync(ChatMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
