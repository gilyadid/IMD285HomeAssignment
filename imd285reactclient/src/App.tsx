import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import Categories from './components/Categories';
import ShoppingList from './components/ShoppingList';
import CategoryProducts from './components/CategoryProducts';
import NavigateToOrder from './components/NavigateToOrder';
import OrderConfirmation from './components/OrderConfirmation';
import { RootState } from './store';
import { clearCart } from './store/cartSlice';
import './App.css';

const App: React.FC = () => {
    const [selectedCategoryId, setSelectedCategoryId] = useState<string>('');
    const [showOrderConfirmation, setShowOrderConfirmation] = useState(false);
    const dispatch = useDispatch();

    const cartItems = useSelector((state: RootState) => state.cart.items);
    const isCartEmpty = cartItems.length === 0;

    const handleOrderConfirmation = () => {
        dispatch(clearCart());
        setSelectedCategoryId('');
        setShowOrderConfirmation(false);
    };

    return (
        <div className="App">
            {showOrderConfirmation ? (
                <OrderConfirmation
                    onBack={() => setShowOrderConfirmation(false)}
                    onConfirm={handleOrderConfirmation}
                />
            ) : (
                <>
                    <div className="top-section">
                        <div className="left-panel">
                            {selectedCategoryId && <CategoryProducts categoryId={selectedCategoryId} />}
                        </div>
                        <div className="right-panel">
                            <Categories onCategorySelect={setSelectedCategoryId} />
                        </div>
                    </div>
                    <div className="middle-section">
                        <ShoppingList />
                    </div>
                    <div className="bottom-section">
                        <NavigateToOrder
                            onNavigate={() => setShowOrderConfirmation(true)}
                            isCartEmpty={isCartEmpty}
                        />
                    </div>
                </>
            )}
        </div>
    );
};

export default App;
