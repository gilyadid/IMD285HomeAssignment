import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../store';
import { Product } from '../store/productsSlice';
import { Category } from '../store/categoriesSlice'; // Import the Category type
import './ShoppingList.css';

const ShoppingList: React.FC = () => {
    const cart = useSelector((state: RootState) => state.cart.items);
    const categories = useSelector((state: RootState) => state.categories.categories);

    // Group cart items by category
    const groupedItems = cart.reduce((acc, item) => {
        const category = item.product.categoryId;
        if (!acc[category]) {
            acc[category] = [];
        }
        acc[category].push(item);
        return acc;
    }, {} as { [key: string]: { product: Product; quantity: number }[] });

    // Helper function to find category Hebrew name by ID
    const getCategoryHebrewName = (categoryId: string): string => {
        const category = categories.find((c: Category) => c.id === categoryId);
        return category ? category.hebrewName : 'Unknown Category';
    };

    return (
        <div className="shopping-list">
            {Object.entries(groupedItems).map(([categoryId, items]) => (
                <div key={categoryId} className="category-column">
                    <h3>{getCategoryHebrewName(categoryId)}</h3>
                    <ul>
                        {items.map(({ product, quantity }) => (
                            <li key={product.id}>
                                {product.hebrewName} - {quantity}
                            </li>
                        ))}
                    </ul>
                </div>
            ))}
        </div>
    );
};

export default ShoppingList;
