using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    public class FactoryMethod
    {
        private static void Main()
        {
            // Note: constructors call Factory Method
            var documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages
            foreach (var document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (var page in document.Pages) Console.WriteLine(" " + page.GetType().Name);
            }
        }
    }

    internal abstract class Page
    {
    }

    internal class SkillsPage : Page
    {
    }

    internal class EducationPage : Page
    {
    }

    internal class ExperiencePage : Page
    {
    }

    internal class IntroductionPage : Page
    {
    }

    internal class ResultsPage : Page
    {
    }

    internal class ConclusionPage : Page
    {
    }

    internal class SummaryPage : Page
    {
    }

    internal class BibliographyPage : Page
    {
    }

    internal abstract class Document
    {
        private readonly List<Page> pages = new List<Page>();

        // Constructor calls abstract Factory method
        public Document()
        {
            CreatePages();
        }

        public List<Page> Pages => pages;

        // Factory Method
        public abstract void CreatePages();
    }

    internal class Resume : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    internal class Report : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}