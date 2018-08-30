using Xamarin.Forms;

namespace App1
{
    public class TopMarginAnimation : BindableObject
    {
        private static readonly BindableProperty FromProperty;
        private static readonly BindableProperty ToProperty;
        private static readonly BindableProperty KeyStartProperty;
        private static readonly BindableProperty KeyEndProperty;

        public double From
        {
            get => (double) GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }
        public double To
        {
            get => (double)GetValue(ToProperty);
            set => SetValue(ToProperty, value);
        }
        public double KeyStart
        {
            get => (double)GetValue(KeyStartProperty);
            set => SetValue(KeyStartProperty, value);
        }
        public double KeyEnd
        {
            get => (double)GetValue(KeyEndProperty);
            set => SetValue(KeyEndProperty, value);
        }

        static TopMarginAnimation()
        {
            FromProperty = BindableProperty.Create(nameof(From), typeof(double), typeof(TopMarginAnimation), 0.0, BindingMode.TwoWay);
            ToProperty = BindableProperty.Create(nameof(To), typeof(double), typeof(TopMarginAnimation), 0.0, BindingMode.TwoWay);
            KeyStartProperty = BindableProperty.Create(nameof(KeyStart), typeof(double), typeof(TopMarginAnimation), 0.0, BindingMode.TwoWay);
            KeyEndProperty = BindableProperty.Create(nameof(KeyEnd), typeof(double), typeof(TopMarginAnimation), 0.0, BindingMode.TwoWay);
        }
    }
}