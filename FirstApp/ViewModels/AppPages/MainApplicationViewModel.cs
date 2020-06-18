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

        public bool WindowVisible { get; set; } = false;

        public int Counter { get; set; } = 0;

        #endregion

        #region Commands

        public ICommand BreakfastCommand { get; set; }
        public ICommand DinnerCommand { get; set; }
        public ICommand SupperCommand { get; set; }
        public ICommand LunchCommand { get; set; }
        public ICommand AddProductCommand { get; set; }

        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }


        #endregion

        #region Constructor

        public MainApplicationViewModel()
        {
            BreakfastList.Add(new Meal { Name = "ryż", Kcal = 360, Fat = 2, Carbs = 74, Proteins = 6 });
            BreakfastList.Add(new Meal { Name = "kasza", Kcal = 360, Fat = 2, Carbs = 74, Proteins = 6 });
            DinnerList.Add(new Meal { Name = "makaron", Kcal = 360, Fat = 2, Carbs = 74, Proteins = 6 });
            SupperList.Add(new Meal { Name = "ser", Kcal = 450, Fat = 31, Carbs = 12, Proteins = 36 });

            this.BreakfastContainer = new Meal { Name = "", Kcal = 0, Fat = 0, Carbs = 0, Proteins = 0 };

            BreakfastCommand = new RelayCommand(() => BreakfastClick());
            DinnerCommand = new RelayCommand(() => DinnerClick());
            SupperCommand = new RelayCommand(() => SupperClick());
            LunchCommand = new RelayCommand(() => LunchClick());
            AddProductCommand = new RelayCommand(() => AddProductClick());

            PlusCommand = new RelayCommand(() => PlusClick());
            MinusCommand = new RelayCommand(() => MinusClick());

            Console.WriteLine(BreakfastList[0].Name);
        }

        #endregion

        #region Private methods

        private void BreakfastClick()
        {
            this.Meal = "Breakfast";
            WindowVisible = true;
            BreakfastContainer = MacroCounter.setContainerValues(BreakfastList);
            setCurrentList();
            setCurrentContainer();

            Counter = breakfastCounter;
        }

        private void DinnerClick()
        {
            this.Meal = "Dinner";
            WindowVisible = true;
            DinnerContainer = MacroCounter.setContainerValues(DinnerList);
            setCurrentList();
            setCurrentContainer();

            Counter = dinnerCounter;
        }

        private void SupperClick()
        {
            this.Meal = "Supper";
            WindowVisible = true;
            SupperContainer = MacroCounter.setContainerValues(SupperList);
            setCurrentList();
            setCurrentContainer();

            Counter = supperCounter;
        }

        private void LunchClick()
        {
            this.Meal = "Lunch";
            WindowVisible = true;
            LunchContainer = MacroCounter.setContainerValues(LunchList);
            setCurrentList();
            setCurrentContainer();

            Counter = lunchCounter;
        }

        private void AddProductClick()
        {
            throw new NotImplementedException();
        }

        private void PlusClick()
        {
            switch (Meal)
            {
                case "Breakfast":
                    breakfastCounter++;
                    Counter = breakfastCounter;
                    break;

                case "Dinner":
                    dinnerCounter++;
                    Counter = dinnerCounter;
                    break;

                case "Supper":
                    supperCounter++;
                    Counter = supperCounter;
                    break;

                case "Lunch":
                    lunchCounter++;
                    Counter = lunchCounter;
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

        #endregion

        #region Private helpers


        private void setCurrentList()
        {
            switch (Meal)
            {
                case "Breakfast":
                    CurrentList = BreakfastList;
                    break;

                case "Dinner":
                    CurrentList = DinnerList;
                    break;

                case "Supper":
                    CurrentList = SupperList;
                    break;

                case "Lunch":
                    CurrentList = LunchList;
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
