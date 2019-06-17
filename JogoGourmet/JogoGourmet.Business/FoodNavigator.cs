using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Business
{
    public class FoodNavigator
    {
        private Domain.FoodChain food;
        private Domain.FoodChain currentNode;
        private bool lastYes = false;

        public FoodNavigator()
        {
            food = new Domain.FoodChain();
            food.Food = "Massa";
            food.IsCategory = true;
            food.Yes = new Domain.FoodChain() { Food = "Lasanha", Parent = food };
            food.No = new Domain.FoodChain() { Food = "Bolo de Chocolate", Parent = food };
            currentNode = food;
        }

        public void AddFood(string foodName, string category, Domain.FoodChain current)
        {
            var newFood = new Domain.FoodChain()
            {
                Food = foodName
            };

            var newCategory = new Domain.FoodChain()
            {
                Food = category,
                Yes = newFood,
                No = current,
                IsCategory = true
            };

            newFood.Parent = newCategory;

            if (lastYes)
                current.Parent.Yes = newCategory;
            else
                current.Parent.No = newCategory;
            current.Parent = newCategory;
        }        

        
        public Domain.FoodChain GetNextYes()
        {
            if (currentNode.IsCategory)
                lastYes = true;
            currentNode = currentNode.Yes;            
            return currentNode;
        }

        public Domain.FoodChain GetNextNo()
        {
            if (currentNode.IsCategory)
                lastYes = false;
            currentNode = currentNode.No;
            return currentNode;
        }

        public Domain.FoodChain StartNodes()
        {
            currentNode = food;
            return currentNode;
        }
    }
}
