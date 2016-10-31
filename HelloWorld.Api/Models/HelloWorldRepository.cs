using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;

namespace HelloWorld.Api.Models
{
    public class HelloWorldRepository
    {
        private static HelloWorldRepository repo = new HelloWorldRepository();

        public static HelloWorldRepository Current
        {
            get { return repo; }
        }

        private List<HelloWorld> data = new List<HelloWorld>
        {
            new HelloWorld {HelloId = 1, HelloWord = "Hello", WorldWord = "World"  }
        };

        private List<HelloWorld> expected = new List<HelloWorld>
        {
            new HelloWorld {HelloId = 1, HelloWord = "Hello", WorldWord = "World"  }
        };

        public IEnumerable<HelloWorld> GetAll()
        {
            return data;
        }

        public HelloWorld Get(int id)
        {
            return data.Where(h => h.HelloId == id).FirstOrDefault();
        }

        public HelloWorld Add(HelloWorld item)
        {
            item.HelloId = data.Count + 1;
            data.Add(item);
            return item;
        }
        
        public void Remove(int id)
        {
            HelloWorld item = Get(id);
            if (item != null)
            {
                data.Remove(item);
            }
        }

        public bool Update(HelloWorld item)
        {
            HelloWorld storedItem = Get(item.HelloId);
            if (storedItem != null)
            {
                storedItem.HelloWord = item.HelloWord;
                storedItem.WorldWord = item.WorldWord;
                return true;
            }
            else
            {
                return false;
            }
        }

        [TestMethod]
        public void CheckList()
        {
            Assert.AreEqual(expected, data);
        }
    }
}