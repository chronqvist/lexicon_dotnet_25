# How to start to develop a react application
npm create vite@latest package-tracker
cd package-tracker
npm install
npm run dev -- --host

# Design decision
- Look at DHL guidlines at https://www.dpdhl-brands.com/en/dhl/
- Download DHL official font (Delivery) at https://www.dpdhl-brands.com/en/dhl/tools/download-center?brands=dhl&term=delivery

# Appwrite account
- You can create an free account at https://cloud.appwrite.io/console/login
- You find information about pricing an limitations at https://appwrite.io/pricing

# Create project

- You must first create a project before creating a site.
    - I named it Lexicon

# How to deploy to Appwrite

I have chosen to this manually because I don't want to polute my git history at Github with trial and error to get things working.

# Build react app

npm run build

Result is stored in the dist/ directory

tar -czvf package-tracker.tar.gz .

# Create site

- When creating site, you must choose "other" as framework

# Done

https://lexicon-package-tracker.appwrite.network/


