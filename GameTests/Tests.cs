using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifeWebApplication;
using GameOfLifeWebApplication.Models;
using NUnit.Framework;

namespace GameTests
{
    [TestFixture]
    public class Tests
    {
        
        [Test]
        public void returnGrid() {
            bool[,] input = new bool[3, 3];
            bool[,] output = Grid.GameLogic(input);
            bool[,] expected = input;

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void EachCellAdjacentToExactlyThreeLiveNeighborsBecomesAlive()
        {
            bool[,] input = new bool[5, 5]
            {
                {false,false,false,false,false },
                {false, false, true,true,false},
                {false, false, false,true,false},
                {false, false, false,false,false},
                {false, false,false,false,false}
            };
            bool[,] output = Grid.GameLogic(input);
            bool[,] expected = new bool[3,3]
            {
                
                {false, true,true},
                {false, true,true},
                {false, false,false},
               
            };

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void IfCellIsAliveAndHasOneOrLessLiveNeighborsItDies()
        {
            bool[,] input = new bool[5, 5]
            {
                {false,false,false,false,false },
                {false, false, true, false,false},
                {false, false, false,false,false},
                {false, false, false,false,false},
                {false, false,false,false,false}
            };
            bool[,] output = Grid.GameLogic(input);
            bool[,] expected = new bool[3,3]
            {

                {false, false, false},
                {false, false,false},
                {false, false,false},
               
            };

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void EachLiveCellWithFourOrMoreNeighborsWillDie()
        {
            bool[,] input = new bool[5, 5]
            {
                {false,false,false,false,false },
                {false, true, true,false,false},
                {false, true, true,false,false},
                {false, true, false,false,false},
                {false, false,false,false,false}
            };
            bool[,] output = Grid.GameLogic(input);
            bool[,] expected = new bool[3, 3]
            {
                
                { true, true,false},
                { false, false,false},
                {true, true, false},
            };

            Assert.AreEqual(expected, output);
        }
    }
}
