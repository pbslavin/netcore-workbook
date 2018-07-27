using BaseProject.Intrastructure;
using BaseProject.Intrastructure.TagHelpers;
using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
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
            foreach (var item in Enumerable.Range(0, 6).Select(i => now.AddDays(i)))
            {
                // Assemble
                //Current day
                var mockDateTimeProvider = new MyMockedDateTimeProvider();
                mockDateTimeProvider.Now = DateTime.Now;
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
                // show the current day
                Assert.Contains(mockDateTimeProvider.Now.DayOfWeek.ToString(), output.Content.GetContent());
            }
        }

        [Fact]
        public void TagHelper_ShouldBeBold()
        {
            var now = DateTime.Now;
            // Assemble
            //Current day
            var mockDateTimeProvider = new MyMockedDateTimeProvider();
            mockDateTimeProvider.Now = DateTime.Now;
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
            // show the bold tag
            Assert.Equal("b", output.TagName.ToString());
            }
    }
}
