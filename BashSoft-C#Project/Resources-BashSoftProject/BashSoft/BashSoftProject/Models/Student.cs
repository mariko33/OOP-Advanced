﻿using System;
using System.Collections.Generic;
using System.Linq;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.Static_data;

namespace BashSoftProject.Models
{
    public class Student:IStudent
    {
        private string username;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.username = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }
        public Student(string userName)
        {
            this.Username = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public void EnrollInCourse(ICourse course)
        {
            if (enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.Username, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            var percentageOfSolvedExam = scores.Sum() /
                (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            var mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }

        public int CompareTo(IStudent other) => this.Username.CompareTo(other.Username);

        public override string ToString() => this.Username;

    }
}