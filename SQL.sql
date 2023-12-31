CREATE TABLE [dbo].[Categories] ( 
  [id] INT IDENTITY NOT NULL,
  [name] VARCHAR(50) NULL,
  CONSTRAINT [PK_Category] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Recipes] ( 
  [id] INT IDENTITY NOT NULL,
  [title] VARCHAR(50) NULL,
  [preparation_methods] TEXT NULL,
  [id_category] INT NULL,
  [id_difficulty] INT NULL,
  [preparation_time] INT NULL,
  [is_approved] BIT NULL,
  [id_user] INT NULL,
  CONSTRAINT [PK_Recipes] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Measures] ( 
  [id] INT IDENTITY NOT NULL,
  [name] VARCHAR(250) NULL,
  CONSTRAINT [PK_Measures] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Ingredients] ( 
  [id] INT IDENTITY NOT NULL,
  [name] VARCHAR(50) NULL,
  CONSTRAINT [PK_Ingredients] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Recipe_Ingredients] ( 
  [id] INT IDENTITY NOT NULL,
  [id_recipe] INT NULL,
  [id_ingredient] INT NULL,
  [qtd] FLOAT NULL,
  [id_measure] INT NULL,
  CONSTRAINT [PK_recipe_ingredient] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Ratings] ( 
  [id] INT IDENTITY NOT NULL,
  [name] VARCHAR(250) NULL,
  CONSTRAINT [PK_rating] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Reviews] ( 
  [id] INT IDENTITY NOT NULL,
  [comment] VARCHAR(50) NULL,
  [id_user] INT NULL,
  [id_rating] INT NULL,
  [id_recipe] INT NULL
);
CREATE TABLE [dbo].[Favourites] ( 
  [id_user] INT NULL,
  [id_recipe] INT NULL,
  [id] INT IDENTITY NOT NULL,
  CONSTRAINT [PK_Favourites] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Users] ( 
  [id] INT IDENTITY NOT NULL,
  [name] VARCHAR(250) NULL,
  [email] VARCHAR(50) NULL,
  [password] VARCHAR(250) NOT NULL,
  [username] VARCHAR(250) NOT NULL,
  [is_admin] BIT NULL,
  [is_blocked] BIT NULL,
  CONSTRAINT [PK_user] PRIMARY KEY ([id])
);
CREATE TABLE [dbo].[Difficulties] ( 
  [id] INT IDENTITY NOT NULL,
  [name] VARCHAR(250) NULL,
  CONSTRAINT [PK_Difficulties] PRIMARY KEY ([id])
);
SET IDENTITY_INSERT [dbo].[Categories] ON;
INSERT INTO [dbo].[Categories] ([id], [name]) VALUES (1, 'Breakfast');
INSERT INTO [dbo].[Categories] ([id], [name]) VALUES (2, 'Lunch');
INSERT INTO [dbo].[Categories] ([id], [name]) VALUES (3, 'Dinner');
INSERT INTO [dbo].[Categories] ([id], [name]) VALUES (4, 'Dessert');
INSERT INTO [dbo].[Categories] ([id], [name]) VALUES (5, 'Snack');
SET IDENTITY_INSERT [dbo].[Categories] OFF;
SET IDENTITY_INSERT [dbo].[Recipes] ON;
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (2, 'Scrambled Eggs on Toast', '1. Crack eggs into a bowl. 2. Whisk eggs. 3. Heat a skillet. 4. Pour eggs into the hot skillet. 5. Stir until eggs are cooked. 6. Serve over slices of toasted bread.', 1, 1, 10, 1, 2);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (3, 'Chicken Salad', '1. Grill chicken. 2. Chop vegetables. 3. Mix everything in a bowl. 4. Serve chilled.', 2, 2, 20, 1, 3);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (4, 'Spaghetti Bolognese', '1. Boil pasta. 2. Cook ground beef. 3. Add sauce. 4. Combine and simmer. 5. Serve hot.', 3, 3, 40, 1, 5);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (5, 'Chocolate Cake', '1. Preheat oven. 2. Mix dry ingredients. 3. Beat wet ingredients. 4. Combine and bake. 5. Frost and serve.', 4, 2, 60, 1, 7);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (6, 'Fruit Salad', '1. Chop fruits. 2. Mix in a bowl. 3. Chill before serving.', 5, 1, 15, 1, 6);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (10, 'asda', 'qweqweqweq', 2, 1, 3, 1, 11);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (11, 'qweq', 'qweqweqe', 2, 1, 12, 0, 11);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (12, '1231', '123123132', 1, 3, 12, 1, 11);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (13, '123', '12313', 1, 1, 12, 1, 11);
INSERT INTO [dbo].[Recipes] ([id], [title], [preparation_methods], [id_category], [id_difficulty], [preparation_time], [is_approved], [id_user]) VALUES (14, '234234', '234234', 2, 2, 12, 0, 13);
SET IDENTITY_INSERT [dbo].[Recipes] OFF;
SET IDENTITY_INSERT [dbo].[Measures] ON;
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (1, 'Teaspoon');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (2, 'Tablespoon');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (3, 'Cup');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (4, 'Ounce');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (5, 'Pound');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (6, 'Gram');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (7, 'Kilogram');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (8, 'Milliliter');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (9, 'Liter');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (10, 'Pinch');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (11, 'Dash');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (12, 'Piece');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (13, 'Slice');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (14, 'Cloves');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (15, 'Pint');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (16, 'Quart');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (17, 'Gallon');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (18, 'Unit');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (19, 'Gram');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (20, 'Pound');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (21, 'Tablespoon');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (22, 'Cup');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (23, 'Cup');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (24, 'Tablespoon');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (25, 'Cup');
INSERT INTO [dbo].[Measures] ([id], [name]) VALUES (26, 'Cup');
SET IDENTITY_INSERT [dbo].[Measures] OFF;
SET IDENTITY_INSERT [dbo].[Ingredients] ON;
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (1, 'Flour');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (2, 'Sugar');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (3, 'Eggs');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (4, 'Milk');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (5, 'Butter');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (6, 'Salt');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (7, 'Pepper');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (8, 'Oil');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (9, 'Onion');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (10, 'Cloves Garlic');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (11, 'Tomato');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (12, 'Cheese');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (13, 'Bread');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (14, 'Rice');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (15, 'Pasta');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (16, 'Chicken');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (17, 'Beef');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (18, 'Fish');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (19, 'Lemon');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (20, 'Lime');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (21, 'Orange');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (22, 'Apple');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (23, 'Banana');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (24, 'Strawberry');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (25, 'Blueberry');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (26, 'Raspberry');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (27, 'Blackberry');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (28, 'Carrot');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (29, 'Broccoli');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (30, 'Spinach');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (31, 'Potato');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (32, 'Avocado');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (33, 'Cucumber');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (34, 'Green beans');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (35, 'Pineapple');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (36, 'Grapes');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (37, 'Watermelon');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (38, 'Mango');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (39, 'Peach');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (40, 'Pear');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (41, 'Plum');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (42, 'Cherry');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (43, 'Cabbage');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (44, 'Celery');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (45, 'Bell pepper');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (46, 'Chili pepper');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (47, 'Mushroom');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (48, 'Zucchini');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (49, 'Asparagus');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (50, 'Lettuce');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (51, 'Olive oil');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (52, 'Vinegar');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (53, 'Soy sauce');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (54, 'Mustard');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (55, 'Ketchup');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (56, 'Honey');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (57, 'Yogurt');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (58, 'Chocolate');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (59, 'Vanilla extract');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (60, 'Cinnamon');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (61, 'Basil');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (62, 'Oregano');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (63, 'Thyme');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (64, 'Rosemary');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (65, 'Nutmeg');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (66, 'Cumin');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (67, 'Paprika');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (68, 'Dill');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (69, 'Ginger');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (70, 'Coriander');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (71, 'Parsley');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (72, 'Bay leaf');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (73, 'Sage');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (74, 'Turmeric');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (75, 'Chives');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (76, 'Cardamom');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (77, 'Cloves');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (78, 'Fennel');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (79, 'Almond');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (80, 'Cashew');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (81, 'Walnut');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (82, 'Pistachio');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (83, 'Chicken breast');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (84, 'Mayonnaise');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (85, 'Dijon mustard');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (86, 'Unsweetened cocoa powder');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (87, 'Baking powder');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (88, 'Kiwi');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (89, 'Spaghetti');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (90, 'Zucchini');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (91, 'Milk');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (92, 'Sugar');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (93, 'Milk');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (94, 'Eggs');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (95, 'Milk');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (96, 'Eggs');
INSERT INTO [dbo].[Ingredients] ([id], [name]) VALUES (97, 'Eggs');
SET IDENTITY_INSERT [dbo].[Ingredients] OFF;
SET IDENTITY_INSERT [dbo].[Recipe_Ingredients] ON;
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (1, 2, 13, 2, 13);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (2, 2, 51, 1, 2);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (3, 2, 3, 3, 18);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (8, 3, 83, 2, 3);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (9, 3, 44, 0.25, 3);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (10, 3, 84, 0.5, 3);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (11, 3, 85, 1, 2);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (12, 3, 19, 2, 2);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (13, 5, 1, 120, 6);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (14, 5, 2, 200, 6);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (15, 5, 86, 35, 6);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (16, 5, 87, 1, 1);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (17, 5, 3, 3, 18);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (18, 6, 24, 1, 3);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (19, 6, 88, 2, 13);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (20, 6, 25, 1, 3);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (21, 6, 36, 1, 3);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (22, 4, 17, 450, 6);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (23, 4, 11, 360, 6);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (24, 4, 9, 1, 18);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (25, 4, 10, 2, 18);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (26, 4, 89, 200, 6);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (27, 10, 90, 23, 19);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (29, 11, 92, 12, 21);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (30, 13, 93, 123, 22);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (31, 13, 94, 123, 23);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (32, 13, 95, 2, 24);
INSERT INTO [dbo].[Recipe_Ingredients] ([id], [id_recipe], [id_ingredient], [qtd], [id_measure]) VALUES (34, 14, 97, 44, 26);
SET IDENTITY_INSERT [dbo].[Recipe_Ingredients] OFF;
SET IDENTITY_INSERT [dbo].[Ratings] ON;
INSERT INTO [dbo].[Ratings] ([id], [name]) VALUES (1, '1 Star');
INSERT INTO [dbo].[Ratings] ([id], [name]) VALUES (2, '2 Stars');
INSERT INTO [dbo].[Ratings] ([id], [name]) VALUES (3, '3 Stars');
INSERT INTO [dbo].[Ratings] ([id], [name]) VALUES (4, '4 Stars');
INSERT INTO [dbo].[Ratings] ([id], [name]) VALUES (5, '5 Stars');
SET IDENTITY_INSERT [dbo].[Ratings] OFF;
SET IDENTITY_INSERT [dbo].[Reviews] ON;
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (2, NULL, 2, 5, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (3, NULL, 3, 4, 5);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (67, NULL, 4, 5, 5);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (68, NULL, 4, 5, 5);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (69, NULL, 5, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (70, NULL, 6, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (71, NULL, 2, 3, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (72, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (74, NULL, 3, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (75, NULL, 4, 4, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (76, NULL, 1, 5, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (77, NULL, 4, 5, 5);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (78, NULL, 5, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (79, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (80, NULL, 2, 3, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (81, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (83, NULL, 3, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (84, NULL, 4, 4, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (85, NULL, 1, 5, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (86, NULL, 4, 5, 5);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (87, NULL, 5, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (88, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (89, NULL, 2, 3, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (90, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (92, NULL, 3, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (93, NULL, 4, 4, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (94, NULL, 2, 5, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (95, NULL, 5, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (96, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (97, NULL, 2, 3, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (98, NULL, 5, 4, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (100, NULL, 3, 3, 2);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (101, NULL, 4, 4, 3);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (102, NULL, 2, 5, 4);
INSERT INTO [dbo].[Reviews] ([id], [comment], [id_user], [id_rating], [id_recipe]) VALUES (103, 'qweqweqweqe', 13, 3, 3);
SET IDENTITY_INSERT [dbo].[Reviews] OFF;
SET IDENTITY_INSERT [dbo].[Favourites] ON;
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 4, 2);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 5, 3);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 6, 4);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 3, 5);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 4, 6);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (3, 5, 7);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (4, 6, 8);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (5, 2, 9);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (6, 3, 10);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (3, 4, 11);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 6, 12);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (3, 5, 13);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (4, 2, 14);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (6, 3, 15);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (3, 4, 16);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (2, 5, 17);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (11, 2, 18);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (11, 2, 19);
INSERT INTO [dbo].[Favourites] ([id_user], [id_recipe], [id]) VALUES (13, 6, 20);
SET IDENTITY_INSERT [dbo].[Favourites] OFF;
SET IDENTITY_INSERT [dbo].[Users] ON;
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (1, 'Jorge', 'Jorge@Assembly.pt', 'B09C600FDDC573F117449B3723F23D64', 'adm', 1, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (2, 'John', 'John@User.pt', 'EE11CBB19052E40B07AAC0CA060C23EE', 'john', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (3, 'Jane', 'Jane@User.pt', '32250170A0DCA92D53EC9624F336CA24', 'jane', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (4, 'Sam', 'Sam@User.pt', '5F4DCC3B5AA765D61D8327DEB882CF99', 'sam', 0, 1);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (5, 'Alice', 'Alice@User.pt', '7C90F2DC82AA5DD4501132F6D074A53A', 'alice', 0, 1);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (6, 'Robert', 'Robert@User.pt', '5A85A44C708B6DC530769E789722956A', 'robert', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (7, 'Emily', 'Emily@User.pt', 'E10ADC3949BA59ABBE56E057F20F883E', 'emily', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (8, 'UserTest', 'userTest@test.com', '2D2AD12E531B030AAD70DB9E06A85604', 'user', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (9, 'jorge', 'jorge@abc.pt', '2D2AD12E531B030AAD70DB9E06A85604', 'jorge', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (10, 'a', 'a@a.pt', '0CC175B9C0F1B6A831C399E269772661', 'a', 1, 1);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (11, 'jorge', 'jorgemassi@jorge.pt ', 'D67326A22642A324AA1B0745F2F17ABB', 'jorge', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (12, 'a', 'a@a.pt', '0CC175B9C0F1B6A831C399E269772661', 'a', 0, 0);
INSERT INTO [dbo].[Users] ([id], [name], [email], [password], [username], [is_admin], [is_blocked]) VALUES (13, 'yuri123', 'yuri@yuri.br ', '9491876179D7A80BB5C86F15DBE31422', 'yuri', 0, 0);
SET IDENTITY_INSERT [dbo].[Users] OFF;
SET IDENTITY_INSERT [dbo].[Difficulties] ON;
INSERT INTO [dbo].[Difficulties] ([id], [name]) VALUES (1, 'Easy');
INSERT INTO [dbo].[Difficulties] ([id], [name]) VALUES (2, 'Medium');
INSERT INTO [dbo].[Difficulties] ([id], [name]) VALUES (3, 'Hard');
INSERT INTO [dbo].[Difficulties] ([id], [name]) VALUES (4, 'Expert');
SET IDENTITY_INSERT [dbo].[Difficulties] OFF;
ALTER TABLE [dbo].[Recipes] ADD CONSTRAINT [FK_Recipes_Categories] FOREIGN KEY ([id_category]) REFERENCES [dbo].[Categories] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Recipes] ADD CONSTRAINT [FK_Recipes_Difficulties] FOREIGN KEY ([id_difficulty]) REFERENCES [dbo].[Difficulties] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Recipes] ADD CONSTRAINT [FK_Recipes_Users] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Users] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Recipe_Ingredients] ADD CONSTRAINT [FK_recipe_ingredient_ingredient] FOREIGN KEY ([id_ingredient]) REFERENCES [dbo].[Ingredients] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Recipe_Ingredients] ADD CONSTRAINT [FK_recipe_ingredient_measure] FOREIGN KEY ([id_measure]) REFERENCES [dbo].[Measures] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Recipe_Ingredients] ADD CONSTRAINT [FK_recipe_ingredient_recipe] FOREIGN KEY ([id_recipe]) REFERENCES [dbo].[Recipes] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Reviews] ADD CONSTRAINT [FK_comment_rating] FOREIGN KEY ([id_rating]) REFERENCES [dbo].[Ratings] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Reviews] ADD CONSTRAINT [FK_comment_recipe] FOREIGN KEY ([id_recipe]) REFERENCES [dbo].[Recipes] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Reviews] ADD CONSTRAINT [FK_comment_user] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Users] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Favourites] ADD CONSTRAINT [FK_favourite_recipe] FOREIGN KEY ([id_recipe]) REFERENCES [dbo].[Recipes] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [dbo].[Favourites] ADD CONSTRAINT [Fk_favourite_user] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Users] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
