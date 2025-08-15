using System.Security.Cryptography.X509Certificates;

namespace PassingEventDataProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProccessCompleted += bl_ProcessCompleted;
            bl.StartProcess();
        }

        public static void bl_ProcessCompleted(object sender, bool IsSuccessful)
        {
            Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully!" : "Failed!"));
        }
    }

    public class ProcessBusinessLogic {

        public event EventHandler<bool> ProccessCompleted;

        public void StartProcess() {
            try {

                Console.WriteLine("Process Started!");

                throw new Exception("Error");

                OnProcessCompeted(true);
            }
            catch (Exception ex)
            {
                OnProcessCompeted(false);
            }
        }

        protected virtual void OnProcessCompeted(bool IsSuccessful) {
            ProccessCompleted?.Invoke(this, IsSuccessful);
        }
    }
}
