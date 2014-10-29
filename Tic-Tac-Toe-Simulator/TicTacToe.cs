using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Simulator
{
    public class TicTacToe : INotifyPropertyChanged
    {
       //Private properties.
        private int[,] game;
        private int xWins;
        private int oWins;
        private int ties;
        private int currentPlayer;
        private bool isWinnerDeclared;
        private string tl;
        private string tm;
        private string tr;
        private string ml;
        private string mm;
        private string mr;
        private string bl;
        private string bm;
        private string br;

        //Public properties
        public Random Random;
        public string TL { get { return tl; } set { tl = value; NotifyPropertyChanged(); } }
        public string TM { get { return tm; } set { tm = value; NotifyPropertyChanged(); } }
        public string TR { get { return tr; } set { tr = value; NotifyPropertyChanged(); } }
        public string ML { get { return ml; } set { ml = value; NotifyPropertyChanged(); } }
        public string MM { get { return mm; } set { mm = value; NotifyPropertyChanged(); } }
        public string MR { get { return mr; } set { mr = value; NotifyPropertyChanged(); } }
        public string BL { get { return bl; } set { bl = value; NotifyPropertyChanged(); } }
        public string BM { get { return bm; } set { bm = value; NotifyPropertyChanged(); } }
        public string BR { get { return br; } set { br = value; NotifyPropertyChanged(); } }
        public int[,] Game { get { return game; } set { game = value; } }
        public int XWins { get { return xWins; } set { xWins = value; NotifyPropertyChanged(); } }
        public int OWins { get { return oWins; } set { oWins = value; NotifyPropertyChanged(); } }
        public int Ties { get { return ties; } set { ties = value; NotifyPropertyChanged(); } }
        public int CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; NotifyPropertyChanged(); } }
        public bool IsWinnerDeclared { get { return isWinnerDeclared; } set { isWinnerDeclared = value; NotifyPropertyChanged(); } }

        
        /// <summary>
        /// Fill the array alternating the chance of O and X simultaneously checking the winner
        /// </summary>
        public void Start()
        {
            Initialize();
            IsWinnerDeclared = false;
            while (IsPlaceLeft())
            {
                int x = Random.Next(0, 3);
                int y = Random.Next(0, 3);
                if (Game[x, y] == 2)
                {
                    if (CurrentPlayer == 1)
                    {
                        Game[x, y] = 1;
                        this.SyncArrayWithView();

                        if (ChooseWinner())
                        {

                            XWins++;
                            IsWinnerDeclared = true;
                            break;

                        }
                        CurrentPlayer = 0;
                    }
                    else
                    {
                        Game[x, y] = 0;

                        this.SyncArrayWithView();
                        if (ChooseWinner())
                        {

                            OWins++;
                            IsWinnerDeclared = true;
                            break;

                        }
                        CurrentPlayer = 1;
                    }


                }


            }
            if (!IsWinnerDeclared)
            {
                Ties++;
                IsWinnerDeclared = true;
                
            }

        }
        /// <summary>
        /// Checks for empty position
        /// </summary>
        /// <returns></returns>
        public bool IsPlaceLeft()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game[i, j] == 2)
                    {
                        count++;
                    }

                }

            }
            return count > 0 ? true : false;

        }
        /// <summary>
        /// Chooses the winner
        /// </summary>
        /// <returns></returns>
        public bool ChooseWinner()
        {
            //Verticals
            if (Game[0, 0] == Game[1, 0] && Game[1, 0] == Game[2, 0] && Game[2, 0] != 2)
            {
                return true;
            }
            if (Game[0, 1] == Game[1, 1] && Game[1, 1] == Game[2, 1] && Game[2, 1] != 2)
            {
                return true;
            }
            if (Game[0, 2] == Game[1, 2] && Game[1, 2] == Game[2, 2] && Game[2, 2] != 2)
            {
                return true;
            }

            //Horizontals
            if (Game[0, 0] == Game[0, 1] && Game[0, 1] == Game[0, 2] && Game[0, 2] != 2)
            {
                return true;
            }
            if (Game[1, 0] == Game[1, 1] && Game[1, 1] == Game[1, 2] && Game[1, 2] != 2)
            {
                return true;
            }
            if (Game[2, 0] == Game[2, 1] && Game[2, 1] == Game[2, 2] && Game[2, 2] != 2)
            {
                return true;
            }

            //Diagonals
            if (Game[0, 0] == Game[1, 1] && Game[1, 1] == Game[2, 2] && Game[2, 2] != 2)
            {
                return true;
            }
            if (Game[0, 2] == Game[1, 1] && Game[1, 1] == Game[2, 0] && Game[2, 0] != 2)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Initializes the game filling 2, meaning blank
        /// </summary>
        public void Initialize()
        {
            CurrentPlayer = 1;
            this.Game = new int[3, 3];
            Random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Game[i, j] = 2;
                }
            }
          
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public TicTacToe()
        {
            Initialize();

        }
        /// <summary>
        /// Synchronizes the array with view 
        /// </summary>
        public void SyncArrayWithView()
        {

            this.TL = this.Game[0, 0].ToString();
            this.TM = this.Game[0, 1].ToString();
            this.TR = this.Game[0, 2].ToString();
            this.ML = this.Game[1, 0].ToString();
            this.MM = this.Game[1, 1].ToString();
            this.MR = this.Game[1, 2].ToString();
            this.BL = this.Game[2, 0].ToString();
            this.BM = this.Game[2, 1].ToString();
            this.BR = this.Game[2, 2].ToString();
            
        }

        #region INotifyPropertyChanged Members

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
