# N-Layer architecture
- Users make requests through the UI layer, which interacts only with the BLL. The BLL, in turn, can call the DAL for data access requests
- The UI layer shouldn't make any requests to the DAL directly, nor should it interact with persistence directly through other means.​
- When a layer is changed or replaced, only those layers that work with it should be impacted

![image](https://user-images.githubusercontent.com/25796029/170863410-e93d5940-740b-49c8-b573-cf831ec26e1a.png)

The current project architecture is presented below:

![image](https://user-images.githubusercontent.com/25796029/170863327-8e594d4f-b157-4480-a252-0bfefc27a15b.png)
