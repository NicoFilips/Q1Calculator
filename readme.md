# Features:
- CoreDomain als nuget package / verfügbar für andere Clients -> abstrahiert und als DI Service genutzt
- Unittests mit Moq, NUnit und FluentAssertion
- CICD: Paketieren der CoreDomain -> diese kann in den GitHub Artifacts runtergeladen werden oder auf nuget.org/ sonstiges nuget Repo deployt werden
- CT: Unittests, Smoketests -> perspektivisch Integrationtests mit der scratch.http Datei
- Mutex, App erkennt anhand der App GUID den Prozess im Taskmanager und öffnet sich nicht doppelt
- Launch Profile für Backend und Frontend
- HttpClients als ExtensionMethod/Middleware für Services in der DI,
- Blazor Frontend als Clientapp mit WebView gerendert
- Material UI
- Theoretisch Crossplatform, also z.b. auch unter Linux lauffähig (abgesehen von Windows32 API Calls -> Fensterpositionierung)

# Future:
- scratch.http könnte die Endpoints validieren (Integrationtests)
- editorconfig bzw. StyleCop scharf schalten
- Codecoverage über GitHub Actions (Cobertura / Coverlet und Reportgenerator)
- Dockerfile für Backend und Frontend, dann theoretisch deployment möglich  
- Refactoren

# Bugs & Lesson learned: 
- HTTP Parameter machen aus einem "+" ein Leerzeichen -> URL Encoding
- Wenn man eine Clientapp konfiguriert, sollte man den Host nicht mit SSR verwenden, da sonst kein HTML mehr ausgeliefert wird
