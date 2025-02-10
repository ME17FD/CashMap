# CashMap - Application de Gestion Financière

Une application de gestion financière permettant de suivre, organiser et optimiser vos finances personnelles ou professionnelles.

## Fonctionnalités

### 1. **Suivi des Dépenses et Revenus**
   L'application permet à l'utilisateur d'ajouter des transactions (revenus ou dépenses) en saisissant des informations telles que :
   - Montant
   - Date
   - Description
   
   **Validation des données :**
   - L'application vérifie les informations saisies pour s'assurer qu'elles sont valides (montant, date, description).
   - Si toutes les données sont valides, la transaction est enregistrée dans la base de données.
   - En cas de données manquantes ou invalides, un message d'erreur est affiché et l'enregistrement de la transaction est empêché.

### 2. **Mise à jour des Graphiques Financiers et des Soldes**
   Après l'ajout d'une transaction, l'application met à jour :
   - Les graphiques financiers pour refléter les nouvelles dépenses et revenus.
   - Les soldes disponibles en fonction des transactions ajoutées.

### 3. **Création de Rapports Financiers**
   L'application permet à l'utilisateur de générer des rapports financiers détaillés en fonction de :
   - La période spécifiée (par exemple, mensuelle, annuelle).
   - Le format souhaité (par exemple, PDF, Excel).

   **Données manquantes ou invalides :**
   - Si des données sont manquantes ou invalides lors de la demande de rapport, un message d'erreur est affiché.

### 4. **Gestion des Budgets**
   L'application permet de suivre et de gérer les budgets personnels ou professionnels en fonction des revenus et des dépenses.

## Prérequis

- Système d'exploitation : Windows, macOS, ou Linux
- Base de données : T-SQl
- Langage de programmation : C#
- Framework : .NET

## Installation

### 1. **Cloner le repository**
   Clonez ce projet en utilisant la commande suivante :
   ```bash
   git clone https://github.com/nom_utilisateur/CashMap.git
   ```
### 2. **Installation des dépendances**
   Selon le langage et le framework utilisés, installez les dépendances nécessaires :
   - Pour un projet **.NET** (C#), exécutez la commande suivante pour restaurer les packages NuGet :
     ```bash
     dotnet restore
     ```
   

### 3. **Configuration de la base de données**
   Configurez la base de données en suivant les instructions du fichier `database_setup.sql` ou en exécutant les migrations appropriées :
   - Si vous utilisez une base de données relationnelle (par exemple, MySQL, SQLite), vous pouvez exécuter le script SQL pour créer les tables nécessaires.
   - Si vous utilisez un ORM (par exemple, Entity Framework pour .NET ou SQLAlchemy pour Python), exécutez les migrations pour générer la base de données.

## Utilisation

1. **Ajouter une Transaction**
   - Ouvrez l'application et allez dans la section "Ajouter une transaction".
   - Saisissez le montant, la date et la description de la transaction.
   - Cliquez sur "Ajouter" pour enregistrer la transaction.

2. **Générer un Rapport Financier**
   - Allez dans la section "Rapports financiers".
   - Sélectionnez la période et le format souhaité pour le rapport (par exemple, mensuel, annuel).
   - Cliquez sur "Générer" pour obtenir le rapport dans le format choisi (PDF, Excel, etc.).

3. **Suivre les Graphiques Financiers**
   - Allez dans la section "Graphiques financiers" pour visualiser les graphiques des dépenses et des revenus en fonction des transactions enregistrées.

4. **Gérer les Budgets**
   - Allez dans la section "Gestion des budgets" pour ajuster les limites de dépenses et suivre l'évolution de vos budgets.

## Captures d'écrans

![Screenshot (25)](https://github.com/user-attachments/assets/14f9a567-653e-4db2-a9b5-a2a952d5303f)

![Screenshot (24)](https://github.com/user-attachments/assets/f0ae0f5c-e133-469a-a168-c8ee8bb4b540)

![Screenshot (23)](https://github.com/user-attachments/assets/70948c03-50d9-4679-ad2c-ba40ef14d2fb)

![Screenshot (22)](https://github.com/user-attachments/assets/432a7b50-4ca5-46ad-9705-de888f18f6d4)

![financial_report2_page-0001](https://github.com/user-attachments/assets/a1d5f454-d9cd-4969-9a22-5da69a5360ae)
Page 1

![financial_report2_page-0002](https://github.com/user-attachments/assets/165ebf3f-be7f-441a-949f-2a1026ff41f5)
Page 2

![image](https://github.com/user-attachments/assets/b2aa3376-a578-4ff7-9a34-963a9095c66d)


## Auteurs

- [Mehdi FADDAK](https://github.com/ME17FD/)
