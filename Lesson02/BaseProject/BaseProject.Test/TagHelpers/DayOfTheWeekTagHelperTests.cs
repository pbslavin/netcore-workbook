﻿using BaseProject.Intrastructure;
using BaseProject.Intrastructure.TagHelpers;
using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BaseProject.Test.TagHelpers
{
    public class MyMockedDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get; set; }
    }
    public class DayOfTheWeekTagHelperTests
    {
        [Fact]
        public void TagHelper_ShouldShowCurrentDayOfTheWeek()
        {
            var now = DateTime.Now;
<<<<<<< HEAD
            foreach (var item in Enumerable.Range(0, 6).Select(i => now.AddDays(i)))
            {
                // Assemble
                //Current day
                var mockDateTimeProvider = new MyMockedDateTimeProvider
                {
                    Now = now
                };
                mockDateTimeProvider.Now = now;
=======
            foreach (var day in Enumerable.Range(0, 6).Select(i => now.AddDays(i)))
            {
                // Assemble
                var mockDateTimeProvider = new MyMockedDateTimeProvider();
                mockDateTimeProvider.Now = day;
>>>>>>> b1d12eb330076f9df7bde8448fea9a99b947b17e
                TagHelper myTagHelper = new DayOfTheWeekTagHelper(mockDateTimeProvider);
                TagHelperContext context = null;
                TagHelperOutput output = new TagHelperOutput(
                    "day-of-week",
                    new TagHelperAttributeList(),
                    (useCachedResult, encoder) =>
                    {
                        var tagHelperContent = new DefaultTagHelperContent();
                        tagHelperContent.SetContent(string.Empty);
                        return Task.FromResult<TagHelperContent>(tagHelperContent);
                    }
                );

                // Act
                myTagHelper.Process(context, output);

                // Assert
<<<<<<< HEAD
                // show the current day
=======
>>>>>>> b1d12eb330076f9df7bde8448fea9a99b947b17e
                Assert.Contains(mockDateTimeProvider.Now.DayOfWeek.ToString(), output.Content.GetContent());
            }
        }

        [Fact]
<<<<<<< HEAD
        public void TagHelper_ShouldBeBold()
        {
            var now = DateTime.Now;
            // Assemble
            //Current day
            var mockDateTimeProvider = new MyMockedDateTimeProvider
            {
                Now = now
            };
=======
        public void TagHelper_ShouldBoldDayOfTheWeek()
        {
            var now = DateTime.Now;
            // Assemble
            var mockDateTimeProvider = new MyMockedDateTimeProvider();
            mockDateTimeProvider.Now = now;
>>>>>>> b1d12eb330076f9df7bde8448fea9a99b947b17e
            TagHelper myTagHelper = new DayOfTheWeekTagHelper(mockDateTimeProvider);
            TagHelperContext context = null;
            TagHelperOutput output = new TagHelperOutput(
                "day-of-week",
                new TagHelperAttributeList(),
                (useCachedResult, encoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                }
            );

            // Act
            myTagHelper.Process(context, output);

            // Assert
<<<<<<< HEAD
            // show the bold tag
            Assert.Equal("b", output.TagName.ToString());
=======
            var content = output.Content.GetContent();
            Assert.Equal("b", output.TagName);
>>>>>>> b1d12eb330076f9df7bde8448fea9a99b947b17e
        }
    }
}
