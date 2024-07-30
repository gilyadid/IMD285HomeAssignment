import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../store';
import { fetchProducts } from '../store/actions';
import { Product } from '../store/productsSlice';
import { addItem, removeItem } from '../store/cartSlice';
import './CategoryProducts.css';

interface CategoryProductsProps {
    categoryId: string;
}

const CategoryProducts: React.FC<CategoryProductsProps> = ({ categoryId }) => {
    const dispatch: AppDispatch = useDispatch();
    const { products, status, error } = useSelector((state: RootState) => state.products);

    useEffect(() => {
        if (categoryId) {
            dispatch(fetchProducts(categoryId));
        }
    }, [categoryId, dispatch]);

    if (status === 'loading') {
        return <div>Loading products...</div>;
    }

    if (status === 'failed') {
        return <div>Error: {error}</div>;
    }

    return (
        <div>
            <label className="productsChoiceLabel" htmlFor="category">מוצרים לבחירה</label>
            <ul>
                {products.map((product: Product) => (
                    <li key={product.id}>
                        {product.hebrewName}
                        <button className="contextButton" onClick={() => dispatch(addItem(product))}>+</button>
                        <button className="contextButton" onClick={() => dispatch(removeItem(product.id))}>-</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CategoryProducts;
