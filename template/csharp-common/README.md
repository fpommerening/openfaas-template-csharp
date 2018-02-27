# Funktionen mit geteilten Bibliotheken

Bei der Nutzung von Functions, die einen Kontext abbilden ist das teilen von Quellcode sinnvoll.
Dies umfasst z.B. Komponenten für den Datenzugriff oder gemeinsame Modelle. Mit dieser Vorlage könnt
ihr eine Projektmappe mit verschiedenen Function-Projekten zusammenfassen und bauen.

Die Logik ist zum großen Teil in Power-Shell Scripten untergebracht.

## Voraussetzungen
- OpenFaaS-CLI (faas-cli.exe) ist unter c:\OpenFaaS\ abgelegt
- .NET Core 2

(!) Hinweis: Alle folgenden Befehlen werden im Root ausgeführt. Dort werden dann die Projektmappe inkl. der Funktionen erstellt.

## Projektstruktur
Im Projektordner befindet sich die Projektmappe und die OpenFaaS-Stack-Definition.
Die gemeinsam genutzten Projekt müssen im Ordner Common liegen.

    ROOT
    |-- Common
    |   |-- Data
    |   |-- Logic
    |
    |-- function1
    |   `-- handler
    |-- function2
    |   `-- handler
    |-- function3
    |   `-- handler
    `-- stack.yml
    `-- stack.sln

## Template herunterladen

Mit der OpenFaaS-CLI werden die Vorlagen aus einen git-Repository geladen.

    c:\OpenFaaS\faas-cli.exe template pull https://github.com/fpommerening/openfaas-template-csharp.git

## Function erstellen
Ist noch keine Projektmappe vorhanden, wird diese angelegt. Der Name entspricht dabei der Ordnernamen. Ein Umbenennen ist möglich.
Das Script verwendet immer die erste gefunden Projektmappe. 
Die OpenFaaS-Stack-Defintion heißt per Default stack.yml. Auch diese kann nach belieben umbenannt werden.

    ps: ./template/csharp-common/new.ps1 myfunction

## Functions bauen
Für den Bau der Docker-Images wird ebenfalls ein Power-Shell-Script verwendet.

    ps: ./template/csharp-common/build.ps1

## Functions bereitstellen
Die Bereitstellung der Functions erfolgt mit den Standard-Funktionen der OpenFaaS-CLI.

    c:\OpenFaaS\faas-cli.exe deploy -f stack.yml
