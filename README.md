# Advanced Web Technology Project <br> Metaverse: Developing Digital Twin experience

# 1. General Interface
![alt text](/images/overview1.png)

![alt text](/images/overview2.png)

![alt text](/images/ai.png)

![alt text](/images/ai-log.png)
AI backend server log (LM-Studio)


# 2. How to Run

You can run it either as a stand-alone application or as a Unity project.

#### 2.1. Run as a Unity project

To run the geoTwin application as a Unity project, follow these steps:

1. Open the Unity project in the Unity Editor.

2. In the Unity Editor, open the `DigitalTwin_City_LiveMap` scene (under Assests).

3. Click the Play button to run the application.

#### 2.2. Run as a stand-alone application

To run the geoTwin application as a exectubale application, follow these steps:

1. Navigate to the ExecutableApp folder.

2. Run DigitalTwinCity.exe.


# 3. AI-Assistant settings

You can input any OpenAI API or **OpenAI compatible API** base path.

```
private const string BASE_PATH = "http://{url:port}/v1";
```

For example using LocalAI backend: 
 - `https://{LocalAI}:8080/v1  `      
 - `8080` is default port for LocalAI

For example using LM-Studio backend:
 - `https://{LM-Studio}:1234/v1   ` 
 - `1234` is default port for LM-Studio

![alt text](/images/api-path.png)


# 4. View exported Unity project in Omniverse

To view the exported Unity project in Omniverse, follow these steps:

1. Open the NVIDIA Omniverse Launcher.
2. In the Exchange menu, search and install the USD Presenter.
3. Launch the USD Presenter tool from the Library menu.
4. Through the USD Presenter, browse to the location of the Omniverse\Omniverse_DigitalTwin\City_LiveMap.usd file.
5. Open the file.

![alt text](/images/omniverse-import.png)