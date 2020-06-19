using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FirstApp
{
    public class MainApplicationViewModel : BaseViewModel
    {

        #region Private vars

        private int breakfastCounter = 0;
        private int dinnerCounter = 0;
        private int supperCounter = 0;
        private int lunchCounter = 0;

        #endregion

        #region Public props

        //Name of meal
        public string Meal { get; set; }

        //Cointainer that includes macros
        public Meal BreakfastContainer { get; set; }
        public Meal DinnerContainer { get; set; }
        public Meal SupperContainer { get; set; }
        public Meal LunchContainer { get; set; }

        public Meal CurrentContainer { get; set; }

        public List<Meal> BreakfastList { get; set; } = new List<Meal>();
        public List<Meal> DinnerList { get; set; } = new List<Meal>();
        public List<Meal> SupperList { get; set; } = new List<Meal>();
        public List<Meal> LunchList { get; set; } = new List<Meal>();

        public List<Meal> CurrentList { get; set; } = new List<Meal>();

        public List<Meal> ProductsList { get; set; } = new List<Meal>();

        public int Counter { get; set; } = 0;

        public bool IfAddProduct { get; set; }
        public bool IfPlusProduct { get; set; }
        public bool WindowVisible { get; set; } = false;

        public Meal NewMeal { get; set; } = new Meal();

        public Meal SelectedItem { get; set; } 

        #endregion

        #region Commands

        public ICommand BreakfastCommand { get; set; }
        public ICommand DinnerCommand { get; set; }
        public ICommand SupperCommand { get; set; }
        public ICommand LunchCommand { get; set; }
        public ICommand AddProductCommand { get; set; }

        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }

        public ICommand InAddCommand { get; set; }
        public ICommand InCancleCommand { get; set; }

        public ICommand OutAddCommand { get; set; }
        public ICommand OutCancleCommand { get; set; }

        #endregion

        #region Constructor

        public MainApplicationViewModel()
        {
            this.BreakfastContainer = new Meal { Name = "", Kcal = 0, Fat = 0, Carbs = 0, Proteins = 0 };
            IfAddProduct = false;

            BreakfastCommand = new RelayCommand(() => BreakfastClick());
            DinnerCommand = new RelayCommand(() => DinnerClick());
            SupperCommand = new RelayCommand(() => SupperClick());
            LunchCommand = new RelayCommand(() => LunchClick());
            AddProductCommand = new RelayCommand(() => AddProductClick());

            PlusCommand = new RelayCommand(() => PlusClick());
            MinusCommand = new RelayCommand(() => MinusClick());

            InAddCommand = new RelayCommand(() => InAddClick());
            InCancleCommand = new RelayCommand(() => InCancleClick());

            OutAddCommand = new RelayCommand(() => OutAddClick());
            OutCancleCommand = new RelayCommand(() => OutCancleClick());
        }

        #endregion

        #region Private methods

        private void BreakfastClick()
        {
            this.Meal = "Breakfast";
            WindowVisible = true;
            setCurrentList();
            setCurrentContainer();
           
            Counter = breakfastCounter;
        }

        private void DinnerClick()
        {
            this.Meal = "Dinner";
            WindowVisible = true;
            setCurrentList();
            setCurrentContainer();

            Counter = dinnerCounter;
        }

        private void SupperClick()
        {
            this.Meal = "Supper";
            WindowVisible = true;
            setCurrentList();
            setCurrentContainer();

            Counter = supperCounter;
        }

        private void LunchClick()
        {
            this.Meal = "Lunch";
            WindowVisible = true;
            setCurrentList();
            setCurrentContainer();

            Counter = lunchCounter;
        }

        private void AddProductClick()
        {
            IfAddProduct = true;
        }

        private void PlusClick()
        {
            switch (Meal)
            {
                case "Breakfast":
                    IfPlusProduct = true;
                    break;

                case "Dinner":
                    IfPlusProduct = true;
                    break;

                case "Supper":
                    IfPlusProduct = true;
                    break;

                case "Lunch":
                    IfPlusProduct = true;
                    break;

                default:
                    break;
            }
        }

        private void MinusClick()
        {
            switch (Meal)
            {
                case "Breakfast":
                    breakfastCounter--;
                    Counter = breakfastCounter;
                    break;

                case "Dinner":
                    dinnerCounter--;
                    Counter = dinnerCounter;
                    break;

                case "Supper":
                    supperCounter--;
                    Counter = supperCounter;
                    break;

                case "Lunch":
                    lunchCounter--;
                    Counter = lunchCounter;
                    break;

                default:
                    break;
            }
        }

        private void InAddClick()
        {
            ProductsList.Add( new Meal {
                Name = NewMeal.Name,
                Kcal = NewMeal.Kcal,
                Proteins = NewMeal.Proteins,
                Fat = NewMeal.Fat,
                Carbs = NewMeal.Carbs
            });

            OnPropertyChanged(nameof(ProductsList));

            NewMeal.Name = "";
            NewMeal.Kcal = 0;
            NewMeal.Proteins = 0;
            NewMeal.Fat = 0;
            NewMeal.Carbs = 0;

            IfAddProduct = false;
        }

        private void InCancleClick()
        {
            IfAddProduct = false;

            NewMeal.Name = "";
            NewMeal.Kcal = 0;
            NewMeal.Proteins = 0;
            NewMeal.Fat = 0;
            NewMeal.Carbs = 0;
        }

        private bool OutAddClick()
        {
            switch (Meal)
            {
                case "Breakfast":
                    BreakfastList.Add(new Meal { Kcal = SelectedItem.Kcal, Name = SelectedItem.Name, Carbs = SelectedItem.Carbs, Fat = SelectedItem.Fat, Proteins = SelectedItem.Proteins });
                    breakfastCounter++;
                    Counter = breakfastCounter;
                    IfPlusProduct = false;
                    setCurrentList();
                    setCurrentContainer();
                    BreakfastContainer = MacroCounter.setContainerValues(BreakfastList);
                    return true;

                case "Dinner":
                    DinnerList.Add(new Meal { Kcal = SelectedItem.Kcal, Name = SelectedItem.Name, Carbs = SelectedItem.Carbs, Fat = SelectedItem.Fat, Proteins = SelectedItem.Proteins });
                    dinnerCounter++;
                    Counter = dinnerCounter;
                    IfPlusProduct = false;
                    setCurrentList();
                    setCurrentContainer();
                    DinnerContainer = MacroCounter.setContainerValues(DinnerList);
                    return true;

                case "Supper":
                    SupperList.Add(new Meal { Kcal = SelectedItem.Kcal, Name = SelectedItem.Name, Carbs = SelectedItem.Carbs, Fat = SelectedItem.Fat, Proteins = SelectedItem.Proteins });
                    supperCounter++;
                    Counter = supperCounter;
                    IfPlusProduct = false;
                    setCurrentList();
                    setCurrentContainer();
                    SupperContainer = MacroCounter.setContainerValues(SupperList);
                    return true;

                case "Lunch":
                    LunchList.Add(new Meal { Kcal = SelectedItem.Kcal, Name = SelectedItem.Name, Carbs = SelectedItem.Carbs, Fat = SelectedItem.Fat, Proteins = SelectedItem.Proteins });
                    lunchCounter++;
                    Counter = lunchCounter;
                    IfPlusProduct = false;
                    setCurrentList();
                    setCurrentContainer();
                    LunchContainer = MacroCounter.setContainerValues(LunchList);
                    return true;

                default:
                    return false;
            }
        }

        private void OutCancleClick()
        {
            IfPlusProduct = false;
        }

        

        #endregion

        #region Private helpers


        private void setCurrentList()
        {
            switch (Meal)
            {
                case "Breakfast":
                    CurrentList = BreakfastList;
                    OnPropertyChanged(nameof(CurrentList));
                    break;

                case "Dinner":
                    CurrentList = DinnerList;
                    OnPropertyChanged(nameof(CurrentList));
                    break;

                case "Supper":
                    CurrentList = SupperList;
                    OnPropertyChanged(nameof(CurrentList));
                    break;

                case "Lunch":
                    CurrentList = LunchList;
                    OnPropertyChanged(nameof(CurrentList));
                    break;

                default:
                    break;
            }
        }

        private void setCurrentContainer()
        {
            switch (Meal)
            {
                case "Breakfast":
                    CurrentContainer = BreakfastContainer;
                    break;

                case "Dinner":
                    CurrentContainer = DinnerContainer;
                    break;

                case "Supper":
                    CurrentContainer = SupperContainer;
                    break;

                case "Lunch":
                    CurrentContainer = LunchContainer;
                    break;

                default:
                    break;
            }
        }



        #endregion
    }
}
