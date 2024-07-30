const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const { elasticClient } = require('./src/elasticClient');

const app = express();
const port = process.env.PORT || 3000;

// Middleware
app.use(bodyParser.json());
app.use(cors());

// Routes
app.post('/api/orders', async (req, res) => {
    try {
        const order = req.body;

        // Save order to Elasticsearch
        await elasticClient.index({
            index: 'orders',
            body: order
        });

        res.status(200).send({ message: 'Order saved successfully' });
    } catch (error) {
        console.error(error);
        res.status(500).send({ error: 'Failed to save order' });
    }
});

// Start server
app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});