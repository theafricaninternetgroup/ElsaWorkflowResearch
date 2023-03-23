using Csla;
using Csla.Blazor;
namespace Elsa.RD.ElsaDrivenUI.ViewModels
{
    public class WizardViewModel<T> :ViewModel<T>
    {
        public WizardViewModel(ApplicationContext appCtx) : base(appCtx) { }

        public int Progress { get; private set; } = 0;
        public int Step { get; private set; } = 1;
        public bool PreviousButtonDisabled { get; private set; } = false;
        public bool NextButtonDisabled { get; private set; } = false;

        public string PreviousButtonCaption { get; private set; } = "Back";
        public string NextButtonCaption { get; private set; } = "Next";

       

        private void SetViewModelState()
        {
            Progress += 20;

            if (Step == 5)
            {
                Progress = 100;
            }
            if (Step == 4)
            {
                PreviousButtonCaption = "Add Another Employee";
                NextButtonCaption = "I have added all Employees";
            }
            else
            {
                PreviousButtonCaption = "Back";
                NextButtonCaption = "Next";
            }
            SetNavButtons();
            
        }
        public void GoToNextStep()
        {
            Step += 1;
            SetViewModelState();
            
        }

        public void GoToPreviousStep()
        {
            
            if (Step > 1 && PreviousButtonCaption != "Add Another Employee")
            {
                Step -= 1;
                Progress -= 20;
            }
            else
            {
                GoTo(2);
            }
            if (Step == 1)
            {
                Progress = 0;
            }
            if (Step == 4)
            {
                PreviousButtonCaption = "Add Another Employee";
                NextButtonCaption = "I have added all Employees";
            }
            else
            {
                PreviousButtonCaption = "Back";
                NextButtonCaption = "Next";
            }
            SetNavButtons();
        }

        public void GoTo(int step)
        { 
            Step = step;
            SetViewModelState();
        }



        public void SetNavButtons()
        {
            NextButtonDisabled = false;
            
        }

    }
}
