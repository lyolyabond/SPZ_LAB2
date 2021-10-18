using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPZ_LAB2
{
    public static class University_with_canteen
    {
        public static decimal Adding_canteen(this decimal income, ref int number_of_staff, 
            decimal payment_for_accommodation, int number_of_students)
        {
            if(payment_for_accommodation == 0)
            { 
            income = payment_for_accommodation * number_of_students;
            } 
            income += income * 0.2m;
            number_of_staff += 5;
            return income;
        }
    }
    class Class
    {
        public class University : ICloneable
        {
            string university_name;
            string address;
            int number_of_rooms;
            int number_of_staff;
            int number_of_students;
            decimal payment_for_accommodation;
            decimal income;
            bool flag = false;
           
            //int i=0;
            public University(string university_name, string address,
            int number_of_rooms, int number_of_staff,
            int number_of_students, decimal payment_for_accommodation)
            {
                this.university_name = university_name;
                this.address = address;
                this.number_of_rooms = number_of_rooms;
                this.number_of_staff = number_of_staff;
                this.number_of_students = number_of_students;
                this.payment_for_accommodation = payment_for_accommodation;

            }
            public string University_name => university_name;
            public string Address => address;
            public int Number_of_rooms => number_of_rooms;
            public int Number_of_staff => number_of_staff;
            public int Number_of_students => number_of_students;
            public decimal Payment_for_accommodation => payment_for_accommodation;
            public decimal Income => income;

            public object Clone()
            {
                University university = new University(this.university_name,
                    this.address, this.number_of_rooms, this.number_of_staff, this.number_of_students,
                    this.payment_for_accommodation);
                return university;
            }
            public void Increase_room(int count_room)
            {
                number_of_rooms += count_room;
            }
            public void Settling(int number_student)
            {
                number_of_students += number_student;
            }
            public void Eviction(int number_student)
            {
                number_of_students -= number_student;
            }
            public decimal IncomeMonth()
            {
                if (!flag)
                    income = payment_for_accommodation * number_of_students;
                return income;
            }

            public decimal IncomeHalfAYear()
            {
                if (flag)
                { return 6 * income; }
                else
                {
                    return 6 * payment_for_accommodation * number_of_students;
                }

               
            }
            public decimal IncomeYear()
            {
                if(flag)
                { return 12 * income; }
                else { 
                return 12 *payment_for_accommodation * number_of_students;
                }
                
            }
            public void Income_with_canteen()
            {
                flag = true;
                income = income.Adding_canteen(ref number_of_staff, payment_for_accommodation, number_of_students);
            }

        }
        
    }
}
