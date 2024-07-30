import React, { useState } from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../store';
import { Product } from '../store/productsSlice';
import './OrderConfirmation.css';

interface OrderConfirmationProps {
    onBack: () => void;
    onConfirm: () => void; // Add this line to include the new prop
}

const OrderConfirmation: React.FC<OrderConfirmationProps> = ({ onBack, onConfirm }) => {
    const [name, setName] = useState('');
    const [address, setAddress] = useState('');
    const [email, setEmail] = useState('');
    const [isConfirmed, setIsConfirmed] = useState(false);
    const [showConfirmationMessage, setShowConfirmationMessage] = useState(false);

    const cartItems = useSelector((state: RootState) => state.cart.items);

    const isFormValid = name && address && email;

    const handleConfirm = () => {
        if (isFormValid) {
            setIsConfirmed(true);
            setShowConfirmationMessage(true);
            onConfirm(); // Call onConfirm when the order is confirmed
        }
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
                        <button onClick={onConfirm}>תודה</button>
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
