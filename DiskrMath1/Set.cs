using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiskrMath1
{
    internal class Set
    {
        List<int> list = new List<int>();
        String name;
        public bool isU = false;

        Set() 
        {
            this.name = "null";
        }
        public Set(string name) 
        { 
            this.name = name;
        }
        public Set(List<int> list, string name)
        {
            this.list = list;
            this.name = name;
        }
        public List<int> GetList() 
        { 
            return this.list; 
        }
        public String GetName() 
        { 
            return this.name; 
        }
        public int GetLength()
        {
            return this.list.Count;
        }
        public int this[int i]
        {
            get
            {
                
                if (i >= 0 && i < this.list.Count)
                    return this.list[i];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set 
            {
                if (i >= 0 && i < this.list.Count)
                    this.list[i] = value;
            }
        }
        public bool isIncluded(int x)
        {
            for (int i = 0; i < this.list.Count; i++) 
            { 
                if (this.list[i] == x) return true;
            }
            return false;
        }
        public bool isIncluded(Set set)
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                bool isDo = false;
                for (int j = 0; j < set.GetLength(); j++)
                {
                    if (this.list[i] == set[j])
                        isDo = true;
                }
                if (!isDo) return false;
            }
            return true;
        }
        public void AddToList(int x)
        {
            this.list.Add(x);
        }
        public void Inter(Set set1, Set set2)
        {
            bool isNull = true;
            for (int i = 0; i < set1.GetLength(); i++)
            {
                for (int j = 0; j < set2.GetLength(); j++) 
                { 
                    if (set1[i] == set2[j])
                    {
                        this.list.Add(set1[i]);
                        isNull = false;
                        break;
                    }
                }
            }
            if (isNull)
            {
                Console.WriteLine("Общих членов множеств нет, множество пустое");
            }
        }
        public void Uni(Set set1, Set set2)
        {
            for (int i = 0; i < set1.GetLength(); i++)
            {
                this.list.Add(set1[i]);
            }
            for (int i = 0; i < set2.GetLength(); i++)
            {
                bool toDo = true;
                for (int j = 0; j < set1.GetLength(); j++)
                {
                    if (set1[j] == set2[i])
                    {
                        toDo = false;
                    }
                }
                if (toDo)
                    this.list.Add(set2[i]);
            }
        }
        public void Diff(Set set1, Set set2)
        {
            for (int i = 0; i < set1.GetLength(); i++)
            {
                this.list.Add(set1[i]);
                for (int j = 0; j < set2.GetLength(); j++)
                {
                    if (set1[i] == set2[j])
                    {
                        this.list.Remove(set1[i]);
                    }
                }
            }
        }
        public void SumDiff(Set set1, Set set2)
        {
            for (int i = 0; i < set1.GetLength(); i++)
            {
                this.list.Add(set1[i]);
                for (int j = 0; j < set2.GetLength(); j++)
                {
                    if (set1[i] == set2[j])
                    {
                        this.list.Remove(set1[i]);
                    }
                }
            }
            for (int i = 0; i < set2.GetLength(); i++)
            {
                this.list.Add(set2[i]);
                for (int j = 0; j < set1.GetLength(); j++)
                {
                    if (set2[i] == set1[j])
                    {
                        this.list.Remove(set2[i]);
                    }
                }
            }
        }
        public void Not(Set set, Set U)
        {
            for (int i = 0; i < U.GetLength(); i++)
            {
                bool toDo = true;
                for (int j = 0; j < set.GetLength(); j++)
                {
                    if (U[i] == set[j]) 
                    { 
                        toDo = false;
                    }
                }
                if (toDo)
                {
                    this.list.Add(U[i]);
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"Множество {this.name}:");
            for (int i = 0; i < this.list.Count; ++i)
            {
                Console.Write(this.list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
