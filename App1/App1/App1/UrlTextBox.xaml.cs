using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace App1
{
    public partial class UrlTextBox
    {
        public static readonly BindableProperty UrlTextProperty;
        public static readonly BindableProperty TopMarginProperty;
        public static readonly BindableProperty AnimationsProperty;
        public static readonly BindableProperty AnimationLengthProperty;
        public static readonly BindableProperty AnimationRateProperty;

        public string UrlText
        {
            get => GetValue(UrlTextProperty).ToString();
            set => SetValue(UrlTextProperty, value);
        }
        public double TopMargin
        {
            get => (double)GetValue(TopMarginProperty);
            set => SetValue(TopMarginProperty, value);
        }
        public ObservableCollection<TopMarginAnimation> Animations
        {
            get => (ObservableCollection<TopMarginAnimation>)GetValue(AnimationsProperty);
            set => SetValue(AnimationsProperty, value);
        }
        public uint AnimationLength
        {
            get => (uint)GetValue(AnimationLengthProperty);
            set => SetValue(AnimationLengthProperty, value);
        }
        public uint AnimationRate
        {
            get => (uint)GetValue(AnimationRateProperty);
            set => SetValue(AnimationRateProperty, value);
        }

        static UrlTextBox()
        {
            UrlTextProperty = BindableProperty.Create(nameof(UrlText), typeof(string), typeof(UrlTextBox), "http://google.com.ua?id=123&text=test", BindingMode.TwoWay);
            TopMarginProperty = BindableProperty.Create(nameof(TopMargin), typeof(double), typeof(UrlTextBox), 0.0);
            AnimationsProperty = BindableProperty.Create(nameof(Animations), typeof(ObservableCollection<TopMarginAnimation>), typeof(UrlTextBox), new ObservableCollection<TopMarginAnimation>());
            AnimationLengthProperty = BindableProperty.Create(nameof(AnimationLength), typeof(uint), typeof(UrlTextBox), 1000U);
            AnimationRateProperty = BindableProperty.Create(nameof(AnimationRate), typeof(uint), typeof(UrlTextBox), 16U);
        }

        public UrlTextBox()
        {
            InitializeComponent();
            UrlEntry.Text = UrlText;
            UrlEntry.TextChanged += OnEntryChanged;
            Animations.CollectionChanged += OnAnimationCollectionChanged;
        }

        private void OnAnimationCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.AbortAnimation("UrlInfoAnimation");
            Animation animation = new Animation();
            foreach (TopMarginAnimation anim in Animations)
            {
                Animation thisAnimation = new Animation(val => TopMargin = val, anim.From, anim.To);
                animation.Add(anim.KeyStart, anim.KeyEnd, thisAnimation);
            }
            animation.Commit(this, "UrlInfoAnimation", AnimationRate, AnimationLength);
        }

        private void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (UrlText != e.NewTextValue)
                UrlText = e.NewTextValue;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == UrlTextProperty.PropertyName && UrlText != UrlEntry.Text)
                UrlEntry.Text = UrlText;
            else if (propertyName == TopMarginProperty.PropertyName)
            {
                Thickness margin = UrlEntry.Margin;
                margin.Top = TopMargin;
                UrlEntry.Margin = margin;
            }
        }
    }
}