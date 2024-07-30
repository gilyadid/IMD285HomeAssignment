import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Product } from './productsSlice';

export interface CartItem {
    product: Product;
    quantity: number;
}

export interface CartState {
    items: CartItem[];
}

const initialState: CartState = {
    items: []
};

const cartSlice = createSlice({
    name: 'cart',
    initialState,
    reducers: {
        addItem: (state, action: PayloadAction<Product>) => {
            const existingItem = state.items.find(item => item.product.id === action.payload.id);
            if (existingItem) {
                existingItem.quantity += 1;
            } else {
                state.items.push({ product: action.payload, quantity: 1 });
            }
        },
        removeItem: (state, action: PayloadAction<string>) => {
            const index = state.items.findIndex(item => item.product.id === action.payload);
            if (index !== -1) {
                state.items[index].quantity -= 1;
                if (state.items[index].quantity <= 0) {
                    state.items.splice(index, 1);
                }
            }
        },
        clearCart: (state) => {
            state.items = [];
        }
    }
});

export const { addItem, removeItem, clearCart } = cartSlice.actions;
export default cartSlice.reducer;
