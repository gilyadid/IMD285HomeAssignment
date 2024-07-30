import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState } from '../store';
import { Product } from '../store/productsSlice';
import { clearCart } from '../store/cartSlice';
import './OrderConfirmation.css';

interface OrderConfirmationProps {
    onBack: () => void;
    onConfirm: () => void;
}

const OrderConfirmation: React.FC<OrderConfirmationProps> = ({ onBack, onConfirm }) => {
    const [name, setName] = useState('');
    const [address, setAddress] = useState('');
    const [email, setEmail] = useState('');
    const [isConfirmed, setIsConfirmed] = useState(false);
    const [showConfirmationMessage, setShowConfirmationMessage] = useState(false);

    const cartItems = useSelector((state: RootState) => state.cart.items);
    const dispatch = useDispatch();

    const isFormValid = name && address && email;

    const handleConfirm = async () => {
        if (isFormValid) {
            try {
                const response = await fetch('http://localhost:3000/api/orders', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ name, address, email, items: cartItems })
                });
                if (response.ok) {
                    setIsConfirmed(true);
                    setShowConfirmationMessage(true);
                } else {
                    console.error('Order submission failed');
                }
            } catch (error) {
                console.error('Error:', error);
            }
        }
    };

    const handleThankYou = () => {
        dispatch(clearCart());
        onConfirm();
    };

    return (
        <div className="order-confirmation">
            <div className="customer-details">
                <h2>פרטי מזמין</h2>
                <input
                    type="text"
                    placeholder="שם פרטי ומשפחה"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="כתובת"
                    value={address}
                    onChange={(e) => setAddress(e.target.value)}
                />
                <input
                    type="email"
                    placeholder="דואר אלקטרוני"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>

            <div className="cart-items">
                <h2>רשימת מוצרים</h2>
                <ul>
                    {cartItems.map(({ product, quantity }: { product: Product, quantity: number }) => (
                        <li key={product.id}>
                            {product.hebrewName} - {quantity}
                        </li>
                    ))}
                </ul>
            </div>

            <div className="buttons">
                {showConfirmationMessage ? (
                    <>
                        <p>ההזמנה אושרה!</p>
                        <button onClick={handleThankYou}>תודה</button>
                    </>
                ) : (
                    <>
                        <button onClick={handleConfirm} disabled={!isFormValid}>
                            אשר הזמנה
                        </button>
                        <button onClick={onBack} disabled={isConfirmed}>
                            שינוי הזמנה
                        </button>
                    </>
                )}
            </div>
        </div>
    );
};

export default OrderConfirmation;
