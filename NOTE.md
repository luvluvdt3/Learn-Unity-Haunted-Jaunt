# -- Haunted Jaunt --
## Link Tuto:
https://learn.unity.com/tutorial/the-player-character-part-1?uv=2020.3&projectId=5caf65ddedbc2a08d53c7acb#61680ef8edbc2a00215ba6a7
## Link Asset:
https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-learn-3d-beginner-tutorial-resources-urp-143848

## Useful trick:
- With your cursor over the Scene view, press F to focus.
-  In the Hierarchy, select the Root GameObject. Hold Alt (Windows) and click the arrow to the left of its name to expand all its child GameObjects.
-  


## Learning:
- The first use for this system in your Project will be to make the character a Prefab.  This means that if you go on to make multiple levels for the game, you won’t need to remake JohnLemon for every level — you can just instantiate a new Prefab. Prefabs can be identified in the Hierarchy window by their blue name and icon.
- Turn the Character into a Prefab
  -  1.  Drag the GameObject from the Hierarchy into the Assets > Prefabs folder in the Project window.  A dialogue box will appear asking if you want to make an Original Prefab or a Prefab Variant — select Original Prefab. ![alt text](image.png)
  -  2.  Now the JohnLemon Prefab has been created, any changes you make to that Prefab will be reflected on the instance of the JohnLemon Prefab in the Scene.  
  -  3.  In the Inspector window, click the Open Prefab button.
  -  4.  Disable the Auto Save checkbox (enabling this will slow you down). A Save button will appear so you can manually save any changes that you make to the Prefab.
  -  5. On the left is an arrow which will take you back along the breadcrumb.  If you clicked the arrow now, it would take you back to MainScene. ![alt text](image-1.png)
