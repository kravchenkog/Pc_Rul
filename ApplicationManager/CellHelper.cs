using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace PC_Rul_Tests
{
    public class CellHelper : HelperBase
    {
        public CellHelper(ApplicationManager apManager) : base(apManager)
        {
            this.apManager = apManager;
        }
       


        public void TapCell(string cellName, int number)
        {
            Dictionary<string,int[,]> points_xy = GetPointsCollection();
            int[,] pointOfCell;
            points_xy.TryGetValue(cellName, out pointOfCell);
            for (int i = 0; i < number; i++)
            {
                IWebElement table_hover = driver.FindElement(By.Id("table"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(table_hover, pointOfCell[i, 0], pointOfCell[i, 1]).Click().Build().Perform();
            }
        }
        public Dictionary<string, int[,]> GetPointsCollection()
        {
            Dictionary<string, int[,]> allPoints = new Dictionary<string, int[,]>();
            allPoints.Add("dozer", GetCells_Dozer());
            allPoints.Add("number", GetCells_Number());
            allPoints.Add("column", GetCells_Column());
            allPoints.Add("lowhigh", GetCells_LowHigh());
            allPoints.Add("evenodd", GetCells_EvenOdd());
            allPoints.Add("pair", GetCells_Pair());
            allPoints.Add("blackred", GetCells_blackred());

            return allPoints;
        }

      
        public void SetBetToRed(string cellName, int number)
        {
            Dictionary<string, int[,]> points_xy = GetPointsCollection();
            int[,] pointOfCell;
            points_xy.TryGetValue(cellName, out pointOfCell);

            for (int i = 0; i < number; i++)
            {
                IWebElement table_hover = driver.FindElement(By.Id("table"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(table_hover, pointOfCell[1, 0], pointOfCell[1, 1]).Click().Build().Perform();
            }

        }

       
        public void SetBetToBlack(string cellName ,int number)
        {
            Dictionary<string, int[,]> points_xy = GetPointsCollection();
            int[,] pointOfCell;
            points_xy.TryGetValue(cellName, out pointOfCell);

            for (int i = 0; i < number; i++)
            {
                IWebElement table_hover = driver.FindElement(By.Id("table"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(table_hover, pointOfCell[1, 0], pointOfCell[1, 1]).Click().Build().Perform();
            }

        }

        public void CellAllBlack_Tap()
        {
            int x = 260;
            int y = 290;
            TapCell(x, y);
        }
        public void CellAllREd_Tap()
        {
            int x = 220;
            int y = 280;
            TapCell(x, y);
        }
        private int[,] GetCells_blackred()
        {
            int[,] cells = new int[3, 2];
            cells[0, 0] = 260;
            cells[0, 1] = 290;
            cells[1, 0] = 220;
            cells[1, 1] = 280;

            return cells;
        }
        private int[,] GetCells_Dozer()
        {
            int[,] cells = new int[3, 2];
            cells[0, 0] = 190;
            cells[0, 1] = 210;
            cells[1, 0] = 260;
            cells[1, 1] = 280;
            cells[2, 0] = 350;
            cells[2, 1] = 295;
            return cells;
        }
        private int[,] GetCells_EvenOdd()
        {
            int[,] cells = new int[2, 2];
            cells[0, 0] = 160;
            cells[0, 1] = 240;
            cells[1, 0] = 340;
            cells[1, 1] = 350;
            return cells;
        }
        private int[,] GetCells_LowHigh()
        {
            int[,] cells = new int[2, 2];
            cells[0, 0] = 100;
            cells[0, 1] = 220;
            cells[1, 0] = 400;
            cells[1, 1] = 390;
            return cells;
        }
        private int[,] GetCells_Column()
        {
            int[,] cells = new int[3, 2];
            cells[0, 0] = 530;
            cells[0, 1] = 340;
            cells[1, 0] = 550;
            cells[1, 1] = 310;
            cells[2, 0] = 570;
            cells[2, 1] = 270;
            return cells;
        }
        private int[,] GetCells_Number()
        {
            int[,] cells = new int[37, 2];
            cells[0, 0] = 80;
            cells[0, 1] = 90;
            cells[1, 0] = 120;
            cells[1, 1] = 120;
            cells[2, 0] = 140;
            cells[2, 1] = 80;
            cells[3, 0] = 180;
            cells[3, 1] = 50;
            cells[4, 0] = 150;
            cells[4, 1] = 130;
            cells[5, 0] = 180;
            cells[5, 1] = 90;
            cells[6, 0] = 220;
            cells[6, 1] = 60;
            cells[7, 0] = 180;
            cells[7, 1] = 150;
            cells[8, 0] = 210;
            cells[8, 1] = 110;
            cells[9, 0] = 240;
            cells[9, 1] = 80;
            cells[10, 0] = 210;
            cells[10, 1] = 170;
            cells[11, 0] = 250;
            cells[11, 1] = 120;
            cells[12, 0] = 270;
            cells[12, 1] = 90;
            cells[13, 0] = 250;
            cells[13, 1] = 190;
            cells[14, 0] = 270;
            cells[14, 1] = 150;
            cells[15, 0] = 310;
            cells[15, 1] = 110;
            cells[16, 0] = 290;
            cells[16, 1] = 210;
            cells[17, 0] = 320;
            cells[17, 1] = 160;
            cells[18, 0] = 350;
            cells[18, 1] = 110;
            cells[19, 0] = 310;
            cells[19, 1] = 230;
            cells[20, 0] = 340;
            cells[20, 1] = 180;
            cells[21, 0] = 370;
            cells[21, 1] = 140;
            cells[22, 0] = 350;
            cells[22, 1] = 250;
            cells[23, 0] = 380;
            cells[23, 1] = 200;
            cells[24, 0] = 410;
            cells[24, 1] = 160;
            cells[25, 0] = 390;
            cells[25, 1] = 270;
            cells[26, 0] = 420;
            cells[26, 1] = 230;
            cells[27, 0] = 440;
            cells[27, 1] = 190;
            cells[28, 0] = 430;
            cells[28, 1] = 300;
            cells[29, 0] = 460;
            cells[29, 1] = 240;
            cells[30, 0] = 480;
            cells[30, 1] = 200;
            cells[31, 0] = 470;
            cells[31, 1] = 320;
            cells[32, 0] = 500;
            cells[32, 1] = 260;
            cells[33, 0] = 520;
            cells[33, 1] = 220;
            cells[34, 0] = 500;
            cells[34, 1] = 330;
            cells[35, 0] = 540;
            cells[35, 1] = 280;
            cells[36, 0] = 560;
            cells[36, 1] = 240;
            return cells;
        }
        private int[,] GetCells_Pair()
        {
            int[,] cells = new int[25, 2];
            cells[0, 0] = 140;
            cells[0, 1] = 120;
            cells[1, 0] = 140;
            cells[1, 1] = 90;
            cells[2, 0] = 160;
            cells[2, 1] = 60;
            cells[3, 0] = 170;
            cells[3, 1] = 90;
            cells[4, 0] = 160;
            cells[4, 1] = 120;
            cells[5, 0] = 210;
            cells[5, 1] = 70;
            cells[6, 0] = 200;
            cells[6, 1] = 120;
            cells[7, 0] = 210;
            cells[7, 1] = 150;
            cells[8, 0] = 230;
            cells[8, 1] = 80;
            cells[9, 0] = 230;
            cells[9, 1] = 110;
            cells[10, 0] = 230;
            cells[10, 1] = 150;
            cells[11, 0] = 230;
            cells[11, 1] = 170;
            cells[12, 0] = 270;
            cells[12, 1] = 130;
            cells[13, 0] = 290;
            cells[13, 1] = 90;
            cells[14, 0] = 280;
            cells[14, 1] = 190;
            cells[15, 0] = 290;
            cells[15, 1] = 190;
            cells[16, 0] = 330;
            cells[16, 1] = 240;
            cells[17, 0] = 360;
            cells[17, 1] = 200;
            cells[18, 0] = 410;
            cells[18, 1] = 180;
            cells[19, 0] = 420;
            cells[19, 1] = 280;
            cells[20, 0] = 440;
            cells[20, 1] = 250;
            cells[21, 0] = 440;
            cells[21, 1] = 270;
            cells[22, 0] = 440;
            cells[22, 1] = 300;
            cells[23, 0] = 520;
            cells[23, 1] = 280;
            cells[24, 0] = 530;
            cells[24, 1] = 330;
            return cells;

        }




        private void Cell_three_19_20_21_Tap()
        {
            int x = 310;
            int y = 240;
            TapCell(x, y);
        }
        private void Cell_four_1_2_4_5_Tap()
        {
            int x = 160;
            int y = 100;
            TapCell(x, y);
        }
        private void Cell_four_5_6_8_9_Tap()
        {
            int x = 210;
            int y = 80;
            TapCell(x, y);
        }
        private void Cell_four_8_9_11_12_Tap()
        {
            int x = 250;
            int y = 110;
            TapCell(x, y);
        }
        private void Cell_four_10_11_13_14_Tap()
        {
            int x = 250;
            int y = 170;
            TapCell(x, y);
        }
        private void Cell_four_13_14_16_17_Tap()
        {
            int x = 290;
            int y = 170;
            TapCell(x, y);
        }
        private void Cell_four_23_24_26_27_Tap()
        {
            int x = 410;
            int y = 210;
            TapCell(x, y);
        }
        private void Cell_four_28_29_31_32_Tap()
        {
            int x = 470;
            int y = 270;
            TapCell(x, y);
        }
        private void Cell_four_32_33_35_36_Tap()
        {
            int x = 520;
            int y = 260;
            TapCell(x, y);
        }
        private void Cell_six_4_9_Tap()
        {
            int x = 160;
            int y = 150;
            TapCell(x, y);
        }
        private void Cell_six_28_31_Tap()
        {
            int x = 420;
            int y = 320;
            TapCell(x, y);
        }
        private void Cell_six_31_34_Tap()
        {
            int x = 470;
            int y = 330;
            TapCell(x, y);
        }
        private void TapCell(int x, int y)
        {
            IWebElement table_hover = driver.FindElement(By.Id("table"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(table_hover, x, y).Click().Build().Perform();
        }

    }
}
