namespace EventsProj
{
    public delegate void Notify(); //delegate
    internal class Program
    {
        static void Main(string[] args)
        {
            var pr = new ProcessBusinessLogic();

            pr.ProcessCompleted += bl_ProcessCompleted; //register with an event
            pr.StartProcess();
        }

        // event handler
        public static void bl_ProcessCompleted() {
            Console.WriteLine("Process Completed");
        }

    }

    //public delegate void Notify();

    public class ProcessBusinessLogic()
    {

        public event Notify ProcessCompleted; //event

        public void StartProcess() {
            Console.WriteLine("Process Started!");

            OnProcessCompeted();
        }

        protected virtual void OnProcessCompeted() {
            ProcessCompleted?.Invoke();
        }
    }
}
