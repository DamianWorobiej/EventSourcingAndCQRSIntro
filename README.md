# EventSourcingAndCQRSIntro
Repository for me to get familiar with the concepts of Event Sourcing and CQRS

I was mostly basing all my code on [this MS documentation](https://learn.microsoft.com/en-us/azure/architecture/patterns/event-sourcing), adding CQRS to hit two birds with one stone.

Major part missing is Queue/Topic that calls event handlers. Instead my command handlers do that. It most likely breaks some rules, but I wanted to keep focused on actual Event Sourcing and CQRS concepts instead of working on figuring out that particular details. I must learn live with that shame for the rest of my days. Or to the day when I'll get inspired enough to address this, whichever comes first.
