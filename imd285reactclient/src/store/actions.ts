import { createAsyncThunk } from '@reduxjs/toolkit';
import { Category } from './categoriesSlice';
import { Product } from './productsSlice';

export const fetchCategories = createAsyncThunk<Category[]>('categories/fetchCategories', async () => {
    const response = await fetch('http://localhost:5000/api/categories');
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    const data = await response.json();
    return data;
});

export const fetchProducts = createAsyncThunk<Product[], string>('products/fetchProducts', async (categoryId) => {
    const response = await fetch(`http://localhost:5000/api/products?categoryId=${categoryId}`);
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    const data = await response.json();
    return data;
});


