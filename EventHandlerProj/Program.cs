namespace EventHandlerProj
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted;
            bl.StartProcess();
        }


        //event handler
        public static void bl_ProcessCompleted(object sender, EventArgs e) {
            Console.WriteLine("Process Completed!");
        }
    }

    public class ProcessBusinessLogic {
        public event EventHandler ProcessCompleted;

        public void StartProcess() {
            Console.WriteLine("Process Started!");

            OnProcessCompleted(EventArgs.Empty); //No event data
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }

}
