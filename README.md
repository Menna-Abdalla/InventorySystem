# Inventory Shop System


![InventoryShopSystem](https://github.com/Menna-Abdalla/InventorySystem/assets/105979665/bb7baad2-8710-4c44-a375-15ec01ad5178)


## Game Elements Interaction

This repository contains a Unity project showcasing four interactive game elements, each represented by a clickable UI button.

### Features:

1. **Shopkeeper Buttons:**
- There are two shopkeeper buttons provided.
- Clicking on either shopkeeper button opens an inventory UI window displaying the items available for purchase from that shopkeeper.
- The player's coin balance is displayed on any corner of the screen, allowing them to purchase items using their coins.
- Purchasing items deducts the appropriate amount from the player's coin balance.

2. **ATM Machine Button:**
- An ATM machine button is available for the player to interact with.
- Clicking on the ATM machine button opens a dedicated ATM UI window.
- The player can deposit or withdraw coins from their bank account using the ATM.
- The player starts with a bank account balance of 3000 coins.

3. **Bed Button:**
- A bed button is provided for the player to interact with.
- Clicking on the bed button allows the player to sleep for 5 seconds and freeze all the UI.
- Upon waking up, the player's bank account balance increases by 10%.
- The player's regular coin balance remains unaffected by sleeping.

### Initial Balances:
- The player starts with 1000 coins in their regular coin balance and 3000 coins in their bank account balance.

### Shopkeepers:
- Each shopkeeper initially sells different items.
- Items sold to shopkeepers are made available for purchase again from their inventory.

### Main Points:
1. All buttons (shopkeepers, ATM machine, bed) are present in the scene UI.
2. Shopkeepers have a dedicated inventory UI showing items for sale.
3. Player's regular coin balance is displayed on the screen.
4. Player can withdraw or deposit coins using the ATM UI.
5. Player can sleep using the bed button, and their bank account balance increases by 10% upon waking up.
6. Shopkeepers are initially selling different items.
7. Player's balances (regular coins and bank account) change appropriately upon interactions with the ATM.
