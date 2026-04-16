# Virtual Art Gallery

An immersive, web-based 3D environment designed to bridge the gap between physical art exhibitions and digital accessibility. Built with **Unity**, **WebGL**, and **Firebase**, this project allows users to explore a realistic gallery space and interact with artwork at their own pace.

## 🚀 Features

* **Immersive 3D Navigation:** Walkthrough experience with smooth character movement and camera controls.
* **Dynamic Artwork Interaction:** Click on paintings or sculptures to view artist statements and details.
* **Web-First Design:** Optimized for WebGL to ensure accessibility via any modern browser.
* **Backend Integration:** Powered by Firebase for hosting and data management.
* **Multi-Platform Profiles:** Custom render pipeline settings for both Mobile and PC performance.

## 🛠️ Tech Stack

* **Engine:** Unity 2022.3+
* **Rendering:** Universal Render Pipeline (URP)
* **Language:** C#
* **Backend & Hosting:** Firebase
* **Version Control:** Git

## 📁 Project Structure

* `/Assets`: Contains all 3D models, textures, materials, and C# scripts.
* `/Packages`: Project dependencies and manifest.
* `/ProjectSettings`: Unity engine configuration files.
* `/webbuild`: The optimized WebGL production build ready for deployment.

## ⚙️ Setup & Installation

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/Skywalker174/VirtualArtGallery.git
    ```
2.  **Open in Unity:**
    * Open Unity Hub and click **Add**.
    * Select the cloned folder.
    * Ensure you have the **WebGL Build Support** module installed.
3.  **Firebase Hosting (Optional):**
    * Navigate to `/webbuild`.
    * Run `firebase deploy` to push changes to the live site.

## 👥 The Team
Developed as part of the CSCI 476 Senior Design at **Bucknell University**.
* **Lead Developers:** Andy Gao, Jason Chung, Muhammad Ahmed, Jean Marie Ngabonziza, Peter Johnstone, Titus Weng.
* **Client:** Philip Baum
* **Mentor:** Professor Brian King

---
*Note: Large binary files (Firebase SDKs and Library files) are excluded via .gitignore. Please ensure you have the necessary Unity packages imported for local development.*
