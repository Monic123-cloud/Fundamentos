# Fundamentos
# Introducción al Aprendizaje Automático (Machine Learning)

Este repositorio contiene un conjunto de ejercicios y cuadernos prácticos orientados a la carga, preprocesamiento y modelado de datos utilizando el clásico dataset **Iris**. 

---

## 📂 Estructura del Repositorio

El repositorio se compone de los siguientes notebooks de Jupyter:

### 1. 📊 Dimensiones (`Dimensiones.ipynb`)
*   **Descripción:** Introducción y toma de contacto con el dataset Iris.
*   **Objetivo:** Carga inicial de los datos, exploración de las características de las plantas e implementación de las fases iniciales de preprocesamiento y análisis dimensional.

### 2. 🤖 Clasificador Iris con KNN (`Clasificador_Iris_KNN.ipynb`)
*   **Descripción:** Implementación de un modelo de aprendizaje supervisado.
*   **Objetivo:** Clasificación de las diferentes especies de Iris utilizando el algoritmo de **K-Vecinos Más Cercanos (K-Nearest Neighbors)**, evaluando la precisión del modelo al predecir etiquetas conocidas.

### 3. 🎯 Agrupamiento con K-Means (`Kmeans_3.ipynb`)
*   **Descripción:** Implementación de un modelo de aprendizaje no supervisado centrado en la longitud y anchura del pétalo.
*   **Objetivo:** Análisis del comportamiento del algoritmo utilizando $K = 2, 3$ y $4$ clústeres. 
*   **Tareas específicas:**
    *   Mapear las fronteras de decisión y ubicar los centroides.
    *   Clasificar y predecir el clúster correspondiente para el punto de prueba `(2.5, 1.0)`.
    *   Calcular la distancia euclidiana exacta desde dicho punto a cada uno de los centroides.

---

## 🛠️ Tecnologías y Librerías Utilizadas
*   **Python 3**
*   **Scikit-Learn:** Para la extracción de los datasets y el uso de los modelos `KMeans` y `KNeighborsClassifier`.
*   **NumPy:** Para la estructuración y manipulación eficiente de matrices de datos.
*   **Matplotlib:** Para el diseño de gráficos estadísticos y mapas visuales de fronteras de decisión.
