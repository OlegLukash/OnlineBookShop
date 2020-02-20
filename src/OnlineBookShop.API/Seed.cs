﻿using Microsoft.AspNetCore.Identity;
using OnlineBookShop.Domain;
using OnlineBookShop.Domain.Auth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShop.API
{
    public class Seed
    {
        public static async Task SeedBooks(OnlineBookShopDbContext context)
        {
            if (!context.Books.Any())
            {
                var bigData = new Book()
                {
                    Title = "Big Data: Principles and best practices of scalable realtime data systems",
                    Description = "SummaryBig Data teaches you to build big data systems using an architecture that takes advantage of clustered hardware along with new tools designed specifically to capture and analyze web-scale data. It describes a scalable, easy-to-understand approach to big data systems that can be built and run by a small team. Following a realistic example, this book guides readers through the theory of big data systems, how to implement them in practice, and how to deploy and operate them once they're built.Purchase of the print book includes a free eBook in PDF, Kindle, and ePub formats from Manning Publications.About the BookWeb-scale applications like social networks, real-time analytics, or e-commerce sites deal with a lot of data, whose volume and velocity exceed the limits of traditional database systems. These applications require architectures built around clusters of machines to store and process data of any size, or speed. Fortunately, scale and simplicity are not mutually exclusive.Big Data teaches you to build big data systems using an architecture designed specifically to capture and analyze web-scale data. This book presents the Lambda Architecture, a scalable, easy-to-understand approach that can be built and run by a small team. You'll explore the theory of big data systems and how to implement them in practice. In addition to discovering a general framework for processing big data, you'll learn specific technologies like Hadoop, Storm, and NoSQL databases.This book requires no previous exposure to large-scale data analysis or NoSQL tools. Familiarity with traditional databases is helpful.What's InsideIntroduction to big data systemsReal-time processing of web-scale dataTools like Hadoop, Cassandra, and StormExtensions to traditional database skillsAbout the AuthorsNathan Marz is the creator of Apache Storm and the originator of the Lambda Architecture for big data systems. James Warren is an analytics architect with a background in machine learning and scientific computing.Table of ContentsA new paradigm for Big DataPART 1 BATCH LAYERData model for Big DataData model for Big Data: IllustrationData storage on the batch layerData storage on the batch layer: IllustrationBatch layerBatch layer: IllustrationAn example batch layer: Architecture and algorithmsAn example batch layer: ImplementationPART 2 SERVING LAYERServing layerServing layer: IllustrationPART 3 SPEED LAYERRealtime viewsRealtime views: IllustrationQueuing and stream processingQueuing and stream processing: IllustrationMicro-batch stream processingMicro-batch stream processing: IllustrationLambda Architecture in depth - from Amzon",
                    PublishedOn = new DateTime(2015, 8, 21),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "Manning Publications"),
                    Price = 120
                };

                var kubernetes = new Book()
                {
                    Title = "Kubernetes in Action",
                    Description = $"Summary Kubernetes in Action is a comprehensive guide to effectively developing and running applications in a Kubernetes environment. Before diving into Kubernetes, the book gives an overview of container technologies like Docker, including how to build containers, so that even readers who haven't used these technologies before can get up and running. Purchase of the print book includes a free eBook in PDF, Kindle, and ePub formats from Manning Publications. About the Technology Kubernetes is Greek for helmsman, your guide through unknown waters. The Kubernetes container orchestration system safely manages the structure and flow of a distributed application, organizing containers and services for maximum efficiency. Kubernetes serves as an operating system for your clusters, eliminating the need to factor the underlying network and server infrastructure into your designs. About the Book Kubernetes in Action teaches you to use Kubernetes to deploy container-based distributed applications. You'll start with an overview of Docker and Kubernetes before building your first Kubernetes cluster. You'll gradually expand your initial application, adding features and deepening your knowledge of Kubernetes architecture and operation. As you navigate this comprehensive guide, you'll explore high-value topics like monitoring, tuning, and scaling. What's Inside Kubernetes' internalsDeploying containers across a clusterSecuring clustersUpdating applications with zero downtime About the Reader Written for intermediate software developers with little or no familiarity with Docker or container orchestration systems. About the Author Marko Luksa is an engineer at Red Hat working on Kubernetes and OpenShift. Table of Contents PART 1 - OVERVIEWIntroducing Kubernetes First steps with Docker and Kubernetes PART 2 - CORE CONCEPTSPods: running containers in Kubernetes Replication and other controllers: deploying managed pods Services: enabling clients to discover and talk to pods Volumes: attaching disk storage to containers ConfigMaps and Secrets: configuring applications Accessing pod metadata and other resources from applications Deployments: updating applications declaratively StatefulSets: deploying replicated stateful applicationsPART 3 - BEYOND THE BASICSUnderstanding Kubernetes internals Securing the Kubernetes API server Securing cluster nodes and the network Managing pods' computational resources Automatic scaling of pods and cluster nodes Advanced scheduling Best practices for developing apps Extending Kubernetes - from Amazon",
                    PublishedOn = new DateTime(2018, 6, 30),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "Manning Publications"),
                    Price = 35
                };

                var adaptiveCode = new Book()
                {
                    Title = "Adaptive Code via C#: Agile coding with design patterns and SOLID principles (Developer Reference)",
                    Description = "Agile coding with design patterns and SOLID principles As every developer knows, requirements are subject to change. But when you build adaptability into your code, you can respond to change more easily and avoid disruptive rework. Focusing on Agile programming, this book describes the best practices, principles, and patterns that enable you to create flexible, adaptive code--and deliver better business value.   Expert guidance to bridge the gap between theory and practice  Get grounded in Scrum: artifacts, roles, metrics, phases  Organize and manage architectural dependencies  Review best practices for patterns and anti-patterns  Master SOLID principles: single-responsibility, open/closed, Liskov substitution  Manage the versatility of interfaces for adaptive code  Perform unit testing and refactoring in tandem  See how delegation and abstraction impact code adaptability  Learn best ways to implement dependency interjection  Apply what you learn to a pragmatic, agile coding project   Get code samples at: http://github.com/garymclean/AdaptiveCode - from Amzon",
                    PublishedOn = new DateTime(2014, 5, 5),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "Microsoft Press"),
                    Price = 50
                };

                var cSharpInDepth = new Book()
                {
                    Title = "C# in Depth, 3rd Edition",
                    Description = "Summary C# in Depth, Third Edition updates the best-selling second edition to cover the new features of C# 5, including the challenges of writing maintainable asynchronous code. It preserves the uniquely insightful look into the tricky areas and dusty corners of C# that only expert Jon Skeet can provide. About this Book If you're a .NET developer, you'll use C# whether you're building an advanced enterprise application or just slamming out a quick app. In C# 5, you can do amazing things with generics, lambda expressions, dynamic typing, LINQ, iterator blocks, and other features. But first you have to learn it in depth. C# in Depth, Third Edition has been thoroughly revised to cover the new features of C# 5, including the subtleties of writing maintainable asynchronous code. You'll see the power of C# in action, learning how to work with high-value features that you'll be glad to have in your toolkit. And you'll learn to avoid hidden pitfalls of C# programming with the help of crystal clear explanations of behind the scenes issues. This book assumes you've digested your first C# book and are hungry for more! Purchase of the print book includes a free eBook in PDF, Kindle, and ePub formats from Manning Publications. What's InsideUpdated for C# 5 The new async/await feature How C# works and whyAbout the Author Jon Skeet is a Senior Software Engineer at Google, and a highly visible participant of newsgroups, user groups, international conferences, and the Stack Overflow Q&A site. Jon spends much of his day coding in Java, but his heart belongs to C#. Table of ContentsPART 1 PREPARING FOR THE JOURNEY The changing face of C# development Core foundations: building on C# 1PART 2 C# 2: SOLVING THE ISSUES OF C# 1 Parameterized typing with genericsSaying nothing with nullable types Fast-tracked delegates Implementing iterators the easy wayConcluding C# 2: the final featuresPART 3 C# 3: REVOLUTIONIZING DATA ACCESS Cutting fluff with a smart compilerLambda expressions and expression treesExtension methods Query expressions and LINQ to ObjectsLINQ beyond collectionsPART 4 C# 4: PLAYING NICELY WITH OTHERS Minor changes to simplify codeDynamic binding in a static languagePART 5 C# 5: ASYNCHRONY MADE SIMPLE Asynchrony with async/await C# 5 bonus features and closing thoughts - from Amzon ",
                    PublishedOn = new DateTime(2013, 3, 3),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "Manning Publications"),
                    Price = 45
                };

                var sqlPerformanceTuning = new Book()
                {
                    Title = "SQL Server 2012 Query Performance Tuning (Expert's Voice in SQL Server)",
                    Description = "Queries not running fast enough? Tired of the phone calls from frustrated users? Grant Fritchey’s book SQL Server 2012 Query Performance Tuning is the answer to your SQL Server query performance problems. The book is revised to cover the very latest in performance optimization features and techniques. It is current with SQL Server 2012. It provides the tools you need to approach your queries with performance in mind. SQL Server 2012 Query Performance Tuning leads you through understanding the causes of poor performance, how to identify them, and how to fix them. You’ll learn to be proactive in establishing performance baselines using tools like Performance Monitor and Extended Events. You’ll learn to recognize bottlenecks and defuse them before the phone rings. You’ll learn some quick solutions too, but emphasis is on designing for performance and getting it right, and upon heading off trouble before it occurs. Delight your users. Silence that ringing phone. Put the principles and lessons from SQL Server 2012 Query Performance Tuning into practice today.Establish performance baselines and monitor against them Troubleshoot and eliminate bottlenecks that frustrate users Plan ahead to achieve the right level of performance - from Amzon ",
                    PublishedOn = new DateTime(2012, 9 , 8),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "Apress"),
                    Price = 40
                };

                var buildingMicroservices = new Book()
                {
                    Title = "Building Microservices with .NET Core 2.0 - Second Edition: Transitioning monolithic architectures using microservices with .NET Core 2.0 using C# 7.0",
                    Description = "Architect your .NET applications by breaking them into really small pieces - microservices - using this practical, example-based guide.Key FeaturesStart your microservices journey and get a broader perspective on microservices development using C# 7.0 with .NET Core 2.0Build, deploy, and test microservices using ASP.Net Core, ASP.NET Core API, and Microsoft Azure CloudUnderstand the basics of reactive microservicesBook DescriptionThe microservices architectural style promotes the development of complex applications as a suite of small services based on business capabilities. This book will help you identify the appropriate service boundaries within your business. We'll start by looking at what microservices are and their main characteristics. Moving forward, you will be introduced to real-life application scenarios; after assessing the current issues, we will begin the journey of transforming this application by splitting it into a suite of microservices using C# 7.0 with .NET Core 2.0. You will identify service boundaries, split the application into multiple microservices, and define service contracts. You will find out how to configure, deploy, and monitor microservices, and configure scaling to allow the application to quickly adapt to increased demand in the future.With an introduction to reactive microservices, you'll strategically gain further value to keep your code base simple, focusing on what is more important rather than on messy asynchronous calls.What you will learnGet acquainted with Microsoft Azure Service FabricCompare microservices with monolithic applications and SOALearn Docker and Azure API managementDefine a service interface and implement APIs using ASP.NET Core 2.0Integrate services using a synchronous approach via RESTful APIs with ASP.NET Core 2.0Implement microservices security using Azure Active Directory, OpenID Connect, and OAuth 2.0Understand the operation and scaling of microservices in .NET Core 2.0Understand the key features of reactive microservices and implement them using reactive extensionsWho This Book Is ForThis book is for .NET Core developers who want to learn and understand the microservices architecture and implement it in their .NET Core applications. It's ideal for developers who are completely new to microservices or just have a theoretical understanding of this architectural approach and want to gain a practical perspective in order to better manage application complexities.Table of ContentsAn Introduction to MicroservicesImplementing MicroservicesIntegration techniques and microservicesTesting microservicesDeploying microservicesSecuring microservicesMonitoring microservicesScaling microservicesIntroduction to Reactive MicroservicesCreating a complete microservice solution - from Amzon ",
                    PublishedOn = new DateTime(2017, 3, 3),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "Packt Publishing"),
                    Price = 32
                };

                var concurrency = new Book()
                {
                    Title = "Concurrency in C# Cookbook: Asynchronous, Parallel, and Multithreaded Programming",
                    Description = "If you're one of the many developers uncertain about concurrent and multithreaded development, this practical cookbook will change your mind. With more than 75 code-rich recipes, author Stephen Cleary demonstrates parallel processing and asynchronous programming techniques, using libraries and language features in .NET 4.5 and C# 5.0.Concurrency is becoming more common in responsive and scalable application development, but it’s been extremely difficult to code. The detailed solutions in this cookbook show you how modern tools raise the level of abstraction, making concurrency much easier than before. Complete with ready-to-use code and discussions about how and why the solution works, you get recipes for using:async and await for asynchronous operationsParallel programming with the Task Parallel LibraryThe TPL Dataflow library for creating dataflow pipelinesCapabilities that Reactive Extensions build on top of LINQUnit testing with concurrent codeInterop scenarios for combining concurrent approachesImmutable, threadsafe, and producer/consumer collectionsCancellation support in your concurrent codeAsynchronous-friendly Object-Oriented ProgrammingThread synchronization for accessing data - from Amzon",
                    PublishedOn = new DateTime(2014, 8, 8),
                    Publisher = context.Publishers.First(publisher => publisher.Name == "O'Reilly Media"),
                    Price = 45
                };

                context.Books.Add(bigData);
                context.Books.Add(kubernetes);
                context.Books.Add(adaptiveCode);
                context.Books.Add(cSharpInDepth);
                context.Books.Add(sqlPerformanceTuning);
                context.Books.Add(buildingMicroservices);
                context.Books.Add(concurrency);

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedPublishers(OnlineBookShopDbContext context)
        {
            if (!context.Publishers.Any())
            {
                var manning = new Publisher()
                {
                    Name = "Manning Publications"
                };

                var microsoftPress = new Publisher()
                {
                    Name = "Microsoft Press"
                };

                var apress = new Publisher()
                {
                    Name = "Apress"
                };

                var oReillyMedia = new Publisher()
                {
                    Name = "O'Reilly Media"
                };

                var packtPublishing = new Publisher()
                {
                    Name = "Packt Publishing"
                };

                context.Publishers.Add(manning);
                context.Publishers.Add(microsoftPress);
                context.Publishers.Add(apress);
                context.Publishers.Add(oReillyMedia);
                context.Publishers.Add(packtPublishing);

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@onlinebookshop.com",
                };

                await userManager.CreateAsync(user, "Qwerty1!");
            }
        }
    }
}
