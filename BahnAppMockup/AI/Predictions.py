from sklearn.ensemble import GradientBoostingRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_squared_error, mean_absolute_error
import pandas as pd

data = pd.read_excel(r"Data_ai2 1.xlsx")
data=data.dropna()
data

# Daten von langer Form in breite Form pivotieren
data_wide = data.pivot(index='Fahrt', columns='Stations', values='Delay in min')

# Spalten umbenennen, damit sie aussagekräftig sind
data_wide.columns = [f'Delay_Station_{int(col)}' for col in data_wide.columns]

# Index zurücksetzen, um 'Fahrt' als Spalte zu haben
data_wide = data_wide.reset_index()

# Daten anzeigen oder speichern
data_wide

# Neue Spaltennamen
column_mapping = {
    'Delay_Station_1': 'Verspätung Köln Hbf',
    'Delay_Station_2': 'Verspätung Köln Messe/ Deutz Bf',
    'Delay_Station_3': 'Verspätung Köln Buchforst',
    'Delay_Station_4': 'Verspätung Köln Mülheim',
    'Delay_Station_5': 'Verspätung Holweide',
    'Delay_Station_6': 'Verspätung Köln Dellbrück',
    'Delay_Station_7': 'Verspätung Duckterath'
}

# Daten umbenennen
data = data_wide.rename(columns=column_mapping)

# Features und Zielvariablen
X = data[['Verspätung Köln Hbf', 'Verspätung Köln Messe/ Deutz Bf']]
y = data[['Verspätung Köln Buchforst', 'Verspätung Köln Mülheim', 'Verspätung Holweide',
          'Verspätung Köln Dellbrück', 'Verspätung Duckterath']]

# Train-Test-Split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Platz für Ergebnisse und Modelle
results = {}
models = {}  # Hier speichern wir die trainierten Modelle

# Trainiere ein Modell pro Zielvariable
for column in y.columns:
    model = GradientBoostingRegressor(random_state=42)
    model.fit(X_train, y_train[column])  # Trainiere mit einer Zielvariable
    models[column] = model  # Speichere das trainierte Modell
    y_pred = model.predict(X_test)

    # Evaluierung
    mse = mean_squared_error(y_test[column], y_pred)
    mae = mean_absolute_error(y_test[column], y_pred)
    results[column] = {'MSE': mse, 'MAE': mae}

# Ergebnisse ausgeben
"""
for target, metrics in results.items():
    print(f"Ergebnisse für {target}:")
    print(f"  Mean Squared Error: {metrics['MSE']}")
    print(f"  Mean Absolute Error: {metrics['MAE']}")
"""

# Funktion für manuelle Vorhersagen
def predict_delays(delay_koeln_hbf, delay_koeln_messe_deutz):
    # Erstelle ein DataFrame mit den Eingaben
    input_data = pd.DataFrame({'Verspätung Köln Hbf': [delay_koeln_hbf], 'Verspätung Köln Messe/ Deutz Bf': [delay_koeln_messe_deutz]})

    # Vorhersagen für jede Zielvariable
    predictions = {}
    for column, model in models.items():
        predictions[column] = model.predict(input_data)[0]  # Vorhersage für die Zielvariable

    return predictions

# Beispiel: Manuelle Eingabe
delay_koeln_hbf = 5
delay_koeln_messe_deutz = 8

predicted_delays = predict_delays(delay_koeln_hbf, delay_koeln_messe_deutz)
print("Vorhergesagte Verspätungen bei einer Verspätung von " + str(delay_koeln_hbf) + 
      " Minuten am Kölner Hbf und einer Verspätung von " + str(delay_koeln_messe_deutz) + " Minuten in Deutz:")
for station, delay in predicted_delays.items():
    print(f"{station}: {delay:.2f} Minuten")
