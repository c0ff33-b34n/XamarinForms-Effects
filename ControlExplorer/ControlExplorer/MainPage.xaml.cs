using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlExplorer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Effect fontEffect;

        int count;
        public MainPage()
        {
            InitializeComponent();

            fontEffect = new LabelFontEffect();

            labelWelcome.Effects.Add(fontEffect);
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            buttonClick.Text = string.Format("Click Count = {0}", ++count);
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            labelWelcome.Effects.Remove(fontEffect);

            if (switchEffects.IsToggled)
                labelWelcome.Effects.Add(fontEffect);
        }

        private void OnSliderColorValueChanged(object sender, ValueChangedEventArgs e)
        {
            Color gradColor = new Color(e.NewValue / 255.0, e.NewValue / 255.0, e.NewValue / 255.0);
            ButtonGradientEffect.SetGradientColor(buttonClick, gradColor);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            buttonClick.Effects.Add(new ButtonGradientEffect());
        }
    }
}