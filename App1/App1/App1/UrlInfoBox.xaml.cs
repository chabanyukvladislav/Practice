using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace App1
{
    public partial class UrlInfoBox
    {
        public static readonly BindableProperty ElementProperty;
        public static readonly BindableProperty TopMarginProperty;
        public static readonly BindableProperty AnimationsProperty;
        public static readonly BindableProperty AnimationLengthProperty;
        public static readonly BindableProperty AnimationRateProperty;

        public UrlInfo Element
        {
            get => GetValue(ElementProperty) as UrlInfo;
            set => SetValue(ElementProperty, value);
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

        static UrlInfoBox()
        {
            ElementProperty = BindableProperty.Create(nameof(Element), typeof(UrlInfo), typeof(UrlInfoBox), new UrlInfo() { Arguments = new Dictionary<string, string>() });
            TopMarginProperty = BindableProperty.Create(nameof(TopMargin), typeof(double), typeof(UrlInfoBox), 0.0);
            AnimationsProperty = BindableProperty.Create(nameof(Animations), typeof(ObservableCollection<TopMarginAnimation>), typeof(UrlInfoBox), new ObservableCollection<TopMarginAnimation>());
            AnimationLengthProperty = BindableProperty.Create(nameof(AnimationLength), typeof(uint), typeof(UrlInfoBox), 1000U);
            AnimationRateProperty = BindableProperty.Create(nameof(AnimationRate), typeof(uint), typeof(UrlInfoBox), 16U);
        }

        public UrlInfoBox()
        {
            InitializeComponent();
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

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ElementProperty.PropertyName)
                BindingContext = Element;
            else if (propertyName == TopMarginProperty.PropertyName)
            {
                Thickness margin = UrlStackPanel.Margin;
                margin.Top = TopMargin;
                UrlStackPanel.Margin = margin;
            }
        }
    }
}