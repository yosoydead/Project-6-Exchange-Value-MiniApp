* The idea of writing an application like this came into my mind near the summer of 2018 when I was bored of always going online and searching for a good website to show me the conversion of Euro/USD to RON.
* After a bit of digging, I found out that my country's National Bank offers the exchange rates of international coins for free as a **XML** document.
* The first time I wrote the app, I did it using WinForms and it was a complete mess 🤡. Did not follow any conventions ♿, put almost all of the code inside the view and that was it. The app was working but it was ugly as 💩 and, most probably, it had its fair share of bugs (one of which I know; if there is no internet connection or the link to the xml document is broken, the app crashes 👌).
* I decided to rewrite that app from scratch.
* **What I've learned** *(kind of)*:
    * how to create an app with WPF
    * some stuff about XAML
    * how to use the MVVM pattern
    * how to interact with the xml document better
    * hook up and subscribe for events in WPF
    * have fun
    * look for ways to solve different problems
    * and probably some other things that don't come to my mind at the moment
* **!Disclaimer** What this app **does not** have at the moment (03.2019) but would be nice to have and I'll try my best to implement them:
    1. threading
    2. multiple views
    3. a better interface
    4. caching
    5. a database to store coin values each day and create a chart that shows how the values have fluctuated in e period of time
    6. a way to convert from Euro to USD or GBP for example (currently it converts coins to RON **only**)
* It's been a fun project that I'll continue to work on and I'm glad that it offered me something new to learn.