import { Merchant } from "./merchant"
import { TransactionType } from "./transactiontype"

export interface Transaction {
    id: string
    amount: number
    status: number
    customerEmail: string
    customerPhone: string
    createdDate: string
    transactionType: TransactionType,
    merchant: Merchant
  }